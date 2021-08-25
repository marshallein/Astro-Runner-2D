using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumperController : MonoBehaviour
{
    [Range(10, 20)]
    public float jumpVelocity;
    public float fallMultiplier;
    public float jumpDistance;
    public LayerMask whatOnGround;
    public Transform groundCheck;
    public float timer = 5f;
    public Animator animator;
    //public GameObject impact;
    //public float MaxHealth;
    Rigidbody2D rb;

    private bool jump = false;
    [SerializeField]
    private bool isGround;
    private float currentTime;
    //private float currentHeath;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            jump = true;
            currentTime = 0f;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Jump(jump);

    }


    void Jump(bool jump)
    {
        if (isGround && jump)
        {
            
            rb.velocity = new Vector2(jumpDistance, jumpVelocity);
            Debug.Log("jump");
            animator.SetBool("Jump", true);
            this.jump = false;
            isGround = false;
            currentTime = timer;

            jumpDistance = -jumpDistance;

        }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void GroundCheck()
    {

        isGround = false;

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, whatOnGround);

        if (collider2Ds.Length > 0)
        {
            animator.SetBool("Jump", false);
            isGround = true;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }


    //public void TakeDamage(int damage)
    //{
    //    currentHeath -= damage;

    //    if (currentHeath <= 0)
    //    {
    //        Die();
    //    }
    //}

    //void Die()
    //{
    //    Instantiate(impact, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}

}
