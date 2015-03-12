using UnityEngine;
using System.Collections;

public class Caster_AI : MonoBehaviour {

	public float enemySpeed = 1f;
	public float jumpForce = 4.0f;
	public Vector2 AIposition;
	public bool facingRight = false;
	
	private GameObject player;
	private GameObject platform;
	
	Collider2D grounded;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	Collider2D playerAround;
	public Collider2D inRange;
	public LayerMask whatIsPlayer;
	float searchRadius = 5.0f;
	float blockRadius = 0.1f;
	
	Collider2D groundAroundLB;
	Collider2D groundAroundRB;
	Collider2D groundAroundRM;
	Collider2D groundAroundLM;
	Collider2D groundAroundLT;
	Collider2D groundAroundRT;
	Collider2D groundAroundRU;
	Collider2D groundAroundLU;
	
	public Transform blockCheckRB;
	public Transform blockCheckLB;
	public Transform blockCheckRM;
	public Transform blockCheckLM;
	public Transform blockCheckRT;
	public Transform blockCheckLT;
	public Transform blockCheckRU;
	public Transform blockCheckLU;
	
	
	void Start ()
	{		
		player = GameObject.FindGameObjectWithTag("Player");
		if (player.transform.position.x > transform.position.x)
			facingRight = true;
		if (player.transform.position.x < transform.position.x)
			facingRight = false;
		if (facingRight)
			Flip ();
		else if (!facingRight)
			Flip ();
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void FixedUpdate ()
	{
		if (player.transform.position.x > transform.position.x)
			facingRight = true;
		if (player.transform.position.x < transform.position.x)
			facingRight = false;

		if (facingRight && gameObject.rigidbody2D.velocity.x < 0)
			Flip ();
		else if (!facingRight && gameObject.rigidbody2D.velocity.x > 0)
			Flip ();
		
		AIposition.x = transform.position.x;
		AIposition.y = transform.position.y;
		
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);
		playerAround = Physics2D.OverlapCircle (AIposition, searchRadius, whatIsPlayer);
		inRange = Physics2D.OverlapCircle (AIposition, searchRadius* 3.0f, whatIsPlayer);
		groundAroundLB = Physics2D.OverlapCircle (blockCheckLB.position, blockRadius, whatIsGround);
		groundAroundRB = Physics2D.OverlapCircle (blockCheckRB.position, blockRadius, whatIsGround);
		groundAroundRM = Physics2D.OverlapCircle (blockCheckRM.position, blockRadius, whatIsGround);
		groundAroundLM = Physics2D.OverlapCircle (blockCheckLM.position, blockRadius, whatIsGround);
		groundAroundRT = Physics2D.OverlapCircle (blockCheckRT.position, blockRadius, whatIsGround);
		groundAroundLT = Physics2D.OverlapCircle (blockCheckLT.position, blockRadius, whatIsGround);
		groundAroundRU = Physics2D.OverlapCircle (blockCheckRU.position, blockRadius, whatIsGround);
		groundAroundLU = Physics2D.OverlapCircle (blockCheckLU.position, blockRadius, whatIsGround);

		Estats statScript = GetComponent<Estats> ();

		if (!statScript.isHit && inRange
			&& (((groundAroundLU) || (!groundAroundLU))
		    || ((groundAroundRU) || (!groundAroundRU)))
		    )
		{
			EMovement ();
		}
		if(playerAround)
			rigidbody2D.velocity = new Vector2(0, 0);
		
/*		if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
		else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
		
		if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
		else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
*/		
	}
	
	void EMovement()
	{
		//		if((!groundAroundLU && !groundAroundL2U) || (!groundAroundRU && !groundAroundR2U))
		//		{ return;}
		if (player.transform.position.x > transform.position.x
		    && ((groundAroundRU) || (!groundAroundRU))
		    ) 
		{
			rigidbody2D.velocity = new Vector2(enemySpeed, rigidbody2D.velocity.y);
		}
		if (player.transform.position.x < transform.position.x
		    && ((groundAroundLU) || (!groundAroundLU))
		    ) 
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
		if(grounded && (player.transform.position.x > transform.position.x 
		                || player.transform.position.x < transform.position.x))
		{
			if ((groundAroundLB) || (groundAroundRB))
			{
				rigidbody2D.AddForce(new Vector2(0, (jumpForce/105)));
			}
			if ((groundAroundLB && !groundAroundLT) 
			    || (groundAroundRB && !groundAroundRT))
			{
				rigidbody2D.AddForce(new Vector2(0, (jumpForce/105)));
			}
		}
	}
}
