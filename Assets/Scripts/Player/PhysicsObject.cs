using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the base class for computing player's movements. 
/// </summary>
public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = 0.65f;
    public float gravityModifier = 1f;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;

    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;

	}
	
	// Update is called once per frame
	void Update () {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
	}

    protected virtual void ComputeVelocity()
    {

    }
    /// <summary>
    /// This is the part where most of the movement calculations happens including Jump and Move.
    /// There are 2 calls to the move functions because first call just calculate's it's position when the player is on the ground & the other call calculates it's movement along the Y  axis.
    /// </summary>
    private void FixedUpdate()
    {
        //Dear old Gravity - I will call this the Uraraka block
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;


        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move,true);
      
    }
    /// <summary>
    /// This code constantly adding objects in the buffer and try to change the position of the player according to the normal vectors.  It also keeps track of the jumping variable Grounded too so any subclass can use it to 
    /// modify behavior like adding a double jump ;-) 
    /// </summary>
    /// <param name="move"></param>
    /// <param name="yMovement"></param>
    /// <remarks>
    /// This code won't be able to handle very steep slopes of more than 45 degrees as it creates problems in the normal calculation it makes the normal value less than minNormal and everything breaks. 
    /// </remarks>
    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if(distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + 0.01f);
            hitBufferList.Clear();
            for(int i=0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }
            for(int i=0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if(currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                float projection = Vector2.Dot(velocity, currentNormal);
                if(projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }


                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
