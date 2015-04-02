using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class First_AI : MonoBehaviour
{

    public float enemySpeed = 15f;
    public float jumpForce = 8.0f;
    public Vector2 AIposition;
    public bool facingRight = false;

    private GameObject player;
    private GameObject platform;

    Collider2D hit;

    Collider2D grounded;
    public Transform groundcheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Collider2D playerAround;
    Collider2D attackRange;
    public LayerMask whatIsPlayer;
    float searchRadius = 15.0f;
    float blockRadius = 0.1f;

    Collider2D groundAroundLB;
    Collider2D groundAroundRB;
    Collider2D groundAroundRM;
    Collider2D groundAroundLM;
    Collider2D groundAroundLT;
    Collider2D groundAroundRT;
    Collider2D groundAroundR2T;
    Collider2D groundAroundL2T;
    Collider2D groundAroundRU;
    Collider2D groundAroundLU;
    Collider2D groundAroundR2U;
    Collider2D groundAroundL2U;

    public Transform blockCheckRB;
    public Transform blockCheckLB;
    public Transform blockCheckRM;
    public Transform blockCheckLM;
    public Transform blockCheckRT;
    public Transform blockCheckLT;
    public Transform blockCheckR2T;
    public Transform blockCheckL2T;
    public Transform blockCheckRU;
    public Transform blockCheckLU;
    public Transform blockCheckR2U;
    public Transform blockCheckL2U;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > transform.position.x)
            facingRight = true;
        if (player.transform.position.x < transform.position.x)
            facingRight = false;
        //if (facingRight)
        //    Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        if (player.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        if (facingRight)
        {
            gameObject.GetComponent<Eattacks>().side = transform.position.x + 2;
        }
        if (!facingRight)
        {
            gameObject.GetComponent<Eattacks>().side = transform.position.x - 2;
        }
        if (facingRight)
        {
            gameObject.GetComponent<Eattacks>().knockbackSide = 0.05f;
        }
        if (!facingRight)
        {
            gameObject.GetComponent<Eattacks>().knockbackSide = -0.05f;
        }
    }

    void FixedUpdate()
    {

        //		if (facingRight && gameObject.rigidbody2D.velocity.x < 0)
        //		{	
        //			Flip ();
        //			Debug.Log("FlipLeft");
        //		}
        //		else if (!facingRight && gameObject.rigidbody2D.velocity.x > 0)
        //		{
        //			FlipRight ();
        //			Debug.Log("FlipRight");
        //		}

        AIposition.x = transform.position.x;
        AIposition.y = transform.position.y;

        attackRange = Physics2D.OverlapCircle(AIposition, 0.5f, whatIsPlayer);
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);
        playerAround = Physics2D.OverlapCircle(AIposition, searchRadius, whatIsPlayer);
        groundAroundLB = Physics2D.OverlapCircle(blockCheckLB.position, blockRadius, whatIsGround);
        groundAroundRB = Physics2D.OverlapCircle(blockCheckRB.position, blockRadius, whatIsGround);
        groundAroundRM = Physics2D.OverlapCircle(blockCheckRM.position, blockRadius, whatIsGround);
        groundAroundLM = Physics2D.OverlapCircle(blockCheckLM.position, blockRadius, whatIsGround);
        groundAroundRT = Physics2D.OverlapCircle(blockCheckRT.position, blockRadius, whatIsGround);
        groundAroundLT = Physics2D.OverlapCircle(blockCheckLT.position, blockRadius, whatIsGround);
        groundAroundR2T = Physics2D.OverlapCircle(blockCheckR2T.position, blockRadius, whatIsGround);
        groundAroundL2T = Physics2D.OverlapCircle(blockCheckL2T.position, blockRadius, whatIsGround);
        groundAroundRU = Physics2D.OverlapCircle(blockCheckRU.position, blockRadius, whatIsGround);
        groundAroundLU = Physics2D.OverlapCircle(blockCheckLU.position, blockRadius, whatIsGround);
        groundAroundR2U = Physics2D.OverlapCircle(blockCheckR2U.position, blockRadius, whatIsGround);
        groundAroundL2U = Physics2D.OverlapCircle(blockCheckL2U.position, blockRadius, whatIsGround);

        Estats statScript = GetComponent<Estats>();

        if (!statScript.isHit && playerAround
            && (((groundAroundLU) || (!groundAroundLU))
            || ((groundAroundRU) || (!groundAroundRU)))
            )
        {
            EMovement();
        }

        if (gameObject.GetComponent<Eattacks>().swinging) gameObject.GetComponent<Animator>().SetInteger("Direction", 2);
        else
        {
            if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
            else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);

            if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
            else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
        }


    }

    void EMovement()
    {
        //		if((!groundAroundLU && !groundAroundL2U) || (!groundAroundRU && !groundAroundR2U))
        //		{ return;}

        if (attackRange)
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

        }
        else
        {
            if (player.transform.position.x > transform.position.x
                    && ((groundAroundRU) || (!groundAroundRU)))
            {
                rigidbody2D.velocity = new Vector2(enemySpeed, rigidbody2D.velocity.y);
            }
            if (player.transform.position.x < transform.position.x
                    && ((groundAroundLU) || (!groundAroundLU)))
            {


                rigidbody2D.velocity = new Vector2(enemySpeed * -1, rigidbody2D.velocity.y);
            }
            if (player.transform.position.x > transform.position.x && !grounded)
            {


                rigidbody2D.velocity = new Vector2(enemySpeed, rigidbody2D.velocity.y);
            }
            if (player.transform.position.x < transform.position.x && !grounded)
            {


                rigidbody2D.velocity = new Vector2(enemySpeed * -1, rigidbody2D.velocity.y);
            }
            if (grounded && (player.transform.position.x > transform.position.x
                    || player.transform.position.x < transform.position.x))
            {
                if ((groundAroundLB && !groundAroundL2T) || (groundAroundRB && !groundAroundR2T))
                {
                    rigidbody2D.AddForce(new Vector2(0, (jumpForce / 105)));
                }
                if ((groundAroundLB && !groundAroundLT && groundAroundL2T)
                        || (groundAroundRB && !groundAroundRT && groundAroundR2T))
                {
                    rigidbody2D.AddForce(new Vector2(0, (jumpForce / 105)));
                }
            }
        }
    }
}
