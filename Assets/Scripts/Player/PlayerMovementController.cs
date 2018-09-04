using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main code connected to the player and inherited from the PhysicsObject class. 
/// It does a lot of things to manage and do some other stuff as well. 
/// </summary>
public class PlayerMovementController : PhysicsObject {


    //This are the movement speed and jumping speed.
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Attack hitbox when player punches
    public GameObject attackBox;

    //This even send out it's state everytime player flips his looking direction.
    public delegate void FlipAction();
    public static event FlipAction OnFlip;


    //To Manage the Canvas that' all. 
    public Transform spitterTransform;
    public Transform chomperTransform;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();
        Vector2 move = Vector2.zero;
        //Inputs and calculations
        move.x = Input.GetAxis("Horizontal");
        
        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if(velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        //Animation control according to the velocity.
        if(velocity.y > 0.01f)
        {
            animator.SetTrigger("jump");
        }
        if(velocity.y < -0.01f)
        {
            animator.SetBool("land",true);
        }

        //Debug.Log(move.x);

        //Management of the player sprite
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            if(OnFlip != null)
            {
                OnFlip();
            }
        }


        HandleLayers();

        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        //This part just manages the canvas of scores above the player
        if (move.x == 0 && grounded)
        {
            spitterTransform.gameObject.SetActive(true);
            chomperTransform.gameObject.SetActive(true);
        }
        else
        {
            spitterTransform.gameObject.SetActive(false);
            chomperTransform.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// This part handles layers in the animation window as the player changes it's movement from ground to jumping in the air.
    /// </summary>
    private void HandleLayers()
    {
        if(!grounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.ResetTrigger("jump");
            animator.SetBool("land", false);
            animator.SetLayerWeight(1, 0);
        }
    }
}
