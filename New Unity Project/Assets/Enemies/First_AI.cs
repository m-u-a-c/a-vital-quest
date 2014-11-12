using UnityEngine;
using System.Collections;

public class First_AI : MonoBehaviour {
	
	public float enemySpeed = 0.1f;
	public float jumpForce = 4f;
	public Vector2 AIposition;
	
	private GameObject player;
	private GameObject platform;
	
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		//myplayer = new Controls ();
	}
	
	void FixedUpdate ()
	{
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
			transform.position = new Vector2 (transform.position.x + enemySpeed, transform.position.y);
			//			if (transform.position.x + enemySpeed =  && grounded)
			//			{
			//				rigidbody2D.AddForce(0, jumpForce);
			//			}
		}
		//move left
		if (player.transform.position.x < transform.position.x && GetDistance () < 1) 
		{	
			transform.position = new Vector2 (transform.position.x - enemySpeed, transform.position.y);
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

