using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] Animator anim;

    private float horizInput;           // store horizontal input for used in FixedUpdate()
    private float moveSpeed = 450.0f;   // 4.5 * 100 newtons

    private float jumpHeight = 3.0f;    // height of jump in units
    private float jumpTime = 0.75f;     // time of jump in seconds
    private float initialJumpVelocity;  // calculated jump velocity
    public float jumpForce = 10f;

    private bool isGrounded = false;    // true if player is grounded
    [SerializeField] private Transform groundCheckPoint;    // draw a circle around this to check ground
    [SerializeField] private LayerMask groundLayerMask;     // a layer for all things ground
    private float groundCheckRadius = 0.3f;                 // radius of ground check circle

    private int jumpMax = 2;            // # of jumps player can do without touching ground
    private int jumpsAvailable = 0;     // current jumps available to player

    private bool facingRight = true;    // true if facing right

    private GameObject player;
    private PlayerHealth playerHealth;
    // public int damageAmount = 10;

    [SerializeField] private Animator plantAnimator;
    [SerializeField] private Animator slugAnimator;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip killSound;
    [SerializeField] private AudioSource audioSrc;

    private void Start()
    {
        // calculate gravity using gravity formula
        float timeToApex = jumpTime / 2.0f;
        float gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        Debug.Log("gravity:" + gravity);

        // adjust gravity scale of player based on gravity required for jumpHeight & jumpTime
        rbody.gravityScale = gravity / Physics2D.gravity.y;

        // calculate jump velocity req'd for jumpHeight & jumpTime
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        
        
    }

    void Update()
    {
        // read & store horizontal input
        horizInput = Input.GetAxis("Horizontal");

        // determine if player is running (for animator param)
        bool isRunning = horizInput > 0.01 || horizInput < -0.01;        
        anim.SetBool("isRunning", isRunning);   // notify animator

        // determine if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
        anim.SetBool("isGrounded", isGrounded); // notify animator

        // reset jumps if grounded
        if (isGrounded)
        {
            jumpsAvailable = jumpMax;
        }

        // if jump is triggered & available - go for it
        if (Input.GetButtonDown("Jump") && jumpsAvailable > 0)
        {
            Jump();
        }

        // Flip player if appropriate
        if( (facingRight && horizInput < -0.01) ||
            (!facingRight && horizInput > 0.01) )
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawSphere(groundCheckPoint.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
       
        float xVel = horizInput * moveSpeed * Time.deltaTime;
        rbody.velocity = new Vector2(xVel, rbody.velocity.y);
    }

    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, initialJumpVelocity);
        jumpsAvailable--;
        anim.SetTrigger("jump");
        audioSrc.PlayOneShot(jumpSound);
    }

    void Flip()
    {
        
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plant_Enemy"))
        {
            //if (transform.position.y > other.gameObject.transform.position.y)
            //{
                /*Debug.Log("Player above enemy");
                Animator enemyAnimator = other.gameObject.GetComponent<Animator>();
                enemyAnimator.SetTrigger("Die");*/
                
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce * 2);
           // plantAnimator.SetTrigger("Die");
            other.gameObject.GetComponent<Animator>().SetTrigger("Die");
            Destroy(other.gameObject);
            audioSrc.PlayOneShot(killSound);




            //}
            //else
            //{
            //    Debug.Log("damage happened");
            //playerHealth.TakeDamage();
            /*anim.SetTrigger("isHurt");*/
            //}
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //if (transform.position.y > other.gameObject.transform.position.y)
            //{
            /*Debug.Log("Player above enemy");
            Animator enemyAnimator = other.gameObject.GetComponent<Animator>();
            enemyAnimator.SetTrigger("Die");*/

            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce * 2);
            // plantAnimator.SetTrigger("Die");
            other.gameObject.GetComponent<Animator>().SetTrigger("Die");
            Destroy(other.gameObject);
            audioSrc.PlayOneShot(killSound);



            //}
            //else
            //{
            //    Debug.Log("damage happened");
            //playerHealth.TakeDamage();
            /*anim.SetTrigger("isHurt");*/
            //}
        }

    }
}
