using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public GameObject attackBox;

    public delegate void FlipAction();
    public static event FlipAction OnFlip;

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

        move.x = Input.GetAxis("Horizontal");

       if(move.x == 0 && grounded)
        {
            spitterTransform.gameObject.SetActive(true);
            chomperTransform.gameObject.SetActive(true);
        }
        else
        {
            spitterTransform.gameObject.SetActive(false);
            chomperTransform.gameObject.SetActive(false);
        }
        
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

        if(velocity.y > 0.01f)
        {
            animator.SetTrigger("jump");
        }
        if(velocity.y < -0.01f)
        {
            animator.SetBool("land",true);
        }

        //Debug.Log(move.x);

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

    }

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
