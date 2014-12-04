using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class First_AI : MonoBehaviour {
	
	public float enemySpeed = 10f;
	public float jumpForce = 4f;
	public Vector2 AIposition;
	
	private GameObject player;
	private GameObject platform;

	public float changetime, timeleft;
	int runsprite = 0;
	bool wayback = false;

	public Sprite still0, run0, run1, run2, run3;

	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool facingRight = true;
	
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
		timeleft -= Time.deltaTime;

		if (facingRight && gameObject.rigidbody2D.velocity.x < 0)
						Flip ();
		else if (!facingRight && gameObject.rigidbody2D.velocity.x > 0)
						Flip ();

		if (Mathf.Abs (gameObject.rigidbody2D.velocity.x) == 0)
						gameObject.GetComponent<SpriteRenderer> ().sprite = still0;

		if (timeleft <= 0 && Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 0) {
			timeleft = changetime;
			switch (runsprite) {
			case 0:
				runsprite++;
				wayback = !wayback;
				gameObject.GetComponent<SpriteRenderer> ().sprite = run0;
				break;
			case 1:
				if (wayback)
					runsprite--;
				else
					runsprite++;
				gameObject.GetComponent<SpriteRenderer> ().sprite = run1;
				break;
			case 2:
				if (wayback)
					runsprite--;
				else
					runsprite++;
				gameObject.GetComponent<SpriteRenderer> ().sprite = run2;
				break;
			case 3:
				runsprite--;
				wayback = true;
				gameObject.GetComponent<SpriteRenderer> ().sprite = run3;
				break;
			}
		}

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

