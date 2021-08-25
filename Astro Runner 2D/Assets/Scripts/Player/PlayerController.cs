using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public variables
    [Range(1, 30)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Transform groundCheck;
    public LayerMask whatOnGround;
    public bool isGround;
    public float speed = 10f;
    //public float maxSpeed = 10f;
    public float maxVelocity;
    public float speedMultipiler;
    public float speedIncreaseMilestone;
    public float distance;
    public Animator animator;
    public GameManager gameManager;
    public float shootSpeed;
    public int shootDamage;
    public int Lives = 3;
    public float currentLives;

    public AudioSource jumpSound;
    public AudioSource hurtSound;
    public AudioSource GameOver;
    #endregion


    private float milestoneCount;
    private float movespeedStore;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;
    const float groundCheckRadius = 0.5f;
    bool jump = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        milestoneCount = speedIncreaseMilestone;
        animator = GetComponent<Animator>();
        currentLives = Lives;
        movespeedStore = speed;
        speedMilestoneCountStore = milestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;
        if (Input.GetButtonUp("Jump")) jump = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        Jump(jump);

        distance += speed * Time.fixedDeltaTime;

        //if (isGround)
        //{
        //    float velocityRatio = velocity.x / maxVelocity;
        //    speed = maxVelocity * (1 - velocityRatio);

        //    velocity.x += speed * Time.fixedDeltaTime;

        //    if (velocity.x >= maxVelocity)
        //    {
        //        velocity.x = maxVelocity;
        //    }

        //}

        if (transform.position.x > milestoneCount)
        {
            milestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultipiler;
            speed *= speedMultipiler;
            shootSpeed *= speedMultipiler;
        }

        if (speed >= maxVelocity)
        {
            speed = maxVelocity;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    void GroundCheck()
    {
        isGround = false;

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatOnGround);
        if (collider2Ds.Length > 0)
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    void Jump(bool jump)
    {

        if (isGround && jump)
        {
            jumpSound.Play();
            isGround = false;
            jump = false;
            animator.SetBool("Jump", true);
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void takeDamage()
    {
        currentLives--;
        hurtSound.Play();
        Debug.Log("player hit");
        if(currentLives <= 0)
        {
            Debug.Log("player die");
            Die();
            
        }
    }


    private void OnBecameInvisible()
    {
        Die();
    }


    void Die()
    {
        GameOver.Play();
        gameManager.RestartGame();
        speed = movespeedStore;
        milestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
        distance = 0;
        currentLives = Lives;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "DeathZone")
    //    {
    //        gameManager.RestartGame();
    //        speed = movespeedStore;
    //        milestoneCount = speedMilestoneCountStore;
    //        speedIncreaseMilestone = speedIncreaseMilestoneStore;
    //        distance = 0;
    //    }
    //}
}
