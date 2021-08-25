using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrabController : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    public float moveSpeed;
    public Animator animator;
    //public GameObject impact;
    //public float MaxHealth;



    public LayerMask whatToDetect;
    public Transform raycastPosition;
    public float raycastDistanceToWall;
    public float raycastDistanceToGround;



    Vector3 baseScale;
    Rigidbody2D rb;
    private bool groundInfo, wallInfo;
    private Vector2 movement;
    private string facing;



    //private float currentHeath;


    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;

        facing = RIGHT;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //currentHeath = MaxHealth;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = moveSpeed;

        if (facing == LEFT)
        {
            x = -moveSpeed;
        }

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (IsfacingWall() || IsNearEdge())
        {
            if (facing == LEFT)
            {
                Flip(RIGHT);
            }
            else if (facing == RIGHT)
            {
                Flip(LEFT);
            }
        }
    }


    private void Flip(string direction)
    {
        Vector3 scale = baseScale;
        if (direction == LEFT)
        {
            scale.x = -baseScale.x;
        }
        else if (direction == RIGHT)
        {
            scale.x = baseScale.x;
        }

        transform.localScale = scale;

        facing = direction;
    }


    private bool IsfacingWall()
    {
        bool val = false;

        float cast = raycastDistanceToWall;

        if (facing == LEFT)
        {
            cast = -raycastDistanceToWall;
        }
        else if (facing == RIGHT)
        {
            cast = raycastDistanceToWall;
        }

        Vector3 target = raycastPosition.position;
        target.x += raycastDistanceToWall;
        Debug.DrawLine(raycastPosition.position, target, Color.red);
        if (Physics2D.Linecast(raycastPosition.position, target, whatToDetect))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }


    private bool IsNearEdge()
    {
        bool val = false;

        float cast = raycastDistanceToGround;

        Vector3 target = raycastPosition.position;
        target.y -= raycastDistanceToGround;

        Debug.DrawLine(raycastPosition.position, target, Color.blue);
        if (Physics2D.Linecast(raycastPosition.position, target, whatToDetect))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
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

    //private void Patrol()
    //{

    //    groundInfo = Physics2D.Raycast(raycastPosition.position, Vector2.down, raycastDistanceToGround, whatToDetect);
    //    wallInfo = Physics2D.Raycast(raycastPosition.position, transform.right, raycastDistanceToWall, whatToDetect);

    //    if (!groundInfo || wallInfo)
    //    {
    //        Flip();
    //    }
    //    else
    //    {
    //        movement.Set(moveSpeed * facing, rb.velocity.y);
    //        rb.velocity = movement * Time.deltaTime;
    //        animator.SetBool("canWalk", true);
    //    }
    //}

    //void Flip()
    //{
    //    facing *= -1;
    //    Debug.Log("change");
    //    transform.Rotate(0.0f, 180.0f, 0.0f);
    //}