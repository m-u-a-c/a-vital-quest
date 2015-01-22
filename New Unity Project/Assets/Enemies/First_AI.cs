using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class First_AI : MonoBehaviour {
	
	public float enemySpeed = 10f;
	public float jumpForce = 4f;
	public Vector2 AIposition;
	public bool facingRight = false;
	private GameObject player;
	private GameObject platform;

	public float changetime, timeleft;
	int runsprite = 0;
	bool wayback = false;

	public Vector2 enemyposition;
	Collider2D grounded;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	void Start ()
	{
		
		player = GameObject.FindGameObjectWithTag("Player");
		//myplayer = new Controls ();
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
        if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
        else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);

		AIposition.x = transform.position.x;
		AIposition.y = transform.position.y;
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);
		EMovement ();
	}
	
	void EMovement()
	{
		if (player.transform.position.x > transform.position.x && GetDistance () < 1) 
		{
			//move right
			//rigidbody2D.velocity = new Vector2 (transform.position.x + enemySpeed, transform.position.y);
			rigidbody2D.velocity = new Vector2(enemySpeed, rigidbody2D.velocity.y);

			facingRight = true;
			//			if (transform.position.x + enemySpeed =  && grounded)
			//			{
			//				rigidbody2D.AddForce(0, jumpForce);
			//			}
		}
		//move left
		if (player.transform.position.x < transform.position.x && GetDistance () < 1) 
		{	
			//rigidbody2D.velocity = new Vector2 (transform.position.x - enemySpeed, transform.position.y) * -1;
			rigidbody2D.velocity = new Vector2(enemySpeed * -1, rigidbody2D.velocity.y);

			facingRight = false;

			//			if (transform.position.x - enemySpeed =  && grounded)
			//			{
			//				rigidbody2D.AddForce(0, jumpForce);
			//			}
		}
		//		if (grounded)
		//		{
		//				if (player.transform.position.y < transform.position.y && GetDistance () < 1)
		//					transform.position = new Vector2 (transform.position.x, transform.position.y - enemySpeed);
		//
		//				if (player.transform.position.y > transform.position.y && GetDistance () < 1)
		//					transform.position = new Vector2 (transform.position.x, transform.position.y + enemySpeed);
		//		}
	}
	
	float GetDistance()
	{
		float tmp = player.transform.position.y - transform.position.y;
		if (tmp < 0)
			tmp *= -1;
		return tmp;
	}
}

