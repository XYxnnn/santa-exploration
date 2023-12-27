using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private int RespawnScene;
    

    public Transform grabDetect;
    private float rayDistance = 0.1f;

    private float horizontalInput;
    private bool isFacingRight = true;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 8f);

    public bool isAlive = true;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource pushSoundEffect;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isAlive)
        {
            //Debug.Log("Alive");
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);


            if (Input.GetKey(KeyCode.Space))
            {
                jumpSoundEffect.Play();
                Jump();
            }


            wallSlide();
            wallJump();

            if (!isWallJumping) { Flip(); }

            //Set animator parameters
            Pushing();
            anim.SetBool("run", horizontalInput != 0);
            //if arrow keys are not pressed, horizontal input = 0. Is 0 != 0? then run = false
            //if arrow keys are pressed, horizontal input > 0, run = true
            anim.SetBool("grounded", isGrounded());
        }

    }

    private void FixedUpdate()
    {
        if (!isWallJumping) { body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); }
    }

    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        if (isGrounded()) 
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
    }

    private void Pushing()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);
        
        
        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            pushSoundEffect.Play();
            Debug.Log("Triggered");
            anim.SetTrigger("push");
        }
            
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if(isWalled() && !isGrounded() && horizontalInput != 0f)
        {
            isWallSliding = true;
            body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void wallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(stopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            body.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(stopWallJumping), wallJumpingDuration);
        }
    }

    private void stopWallJumping()
    {
        isWallJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log("Dead");
        anim.SetTrigger("dead");

        Invoke("LoadRespawnScene", 0.5f);
    }

    private void LoadRespawnScene()
    {
        SceneManager.LoadScene(RespawnScene);
    }

}
