using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 50f;
	public float jumptime = 20000f;

	public Sprite run0, run1, run2, run3, standing0, standing1, standing2, standing3, jumping0, jumping1, falling0, falling1;

	public Vector2 playerposition;
	Collider2D grounded;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float platformspeed = 0;
	
	//flipping
	public bool facingRight = true;

	public float changetime, changetime_jump, changetime_still;
	public float timeleft, timeleft_jump, timeleft_still;
	bool moving = false;
	int runsprite = 0, jumpsprite = 0, stillsprite = 0;
	bool wayback = true, wayback_still = true;
	public float speed;

	void FixedUpdate ()
	{

		speed = gameObject.rigidbody2D.velocity.x;
		moving = !(Mathf.Abs(gameObject.rigidbody2D.velocity.x) < 3);
		timeleft -= Time.deltaTime;
		timeleft_jump -= Time.deltaTime;
		timeleft_still -= Time.deltaTime;

		if (timeleft_jump <= 0 && !grounded) {
			timeleft_jump = changetime_jump;
			if (gameObject.rigidbody2D.velocity.y > -2 && gameObject.rigidbody2D.velocity.y != 0)
			{
				if (jumpsprite == 0)
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = jumping0;
					jumpsprite = 1;
				}
				else
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = jumping1;
					jumpsprite = 0;
				}
			}
			else if (gameObject.rigidbody2D.velocity.y < -2)
			{
				if (jumpsprite == 0)
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = falling0;
					jumpsprite = 1;
				}
				else
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = falling1;
					jumpsprite = 0;
				}
			}
		}
		
		if (timeleft_still <= 0 && grounded && !moving) {
			timeleft_still = changetime_still;
			switch (stillsprite) {
			case 0:
				stillsprite++;
				wayback_still = !wayback_still;
				gameObject.GetComponent<SpriteRenderer> ().sprite = standing0;
				break;
			case 1:
				if (wayback)
					stillsprite--;
				else
					stillsprite++;
				gameObject.GetComponent<SpriteRenderer> ().sprite = standing1;
				break;
			case 2:
				if (wayback)
					stillsprite--;
				else
					stillsprite++;
				gameObject.GetComponent<SpriteRenderer> ().sprite = standing2;
				break;
			case 3:
				stillsprite--;
				wayback_still = true;
				gameObject.GetComponent<SpriteRenderer> ().sprite = standing3;
				break;
			}	
		}

		if (timeleft <= 0 && moving && grounded) {
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

		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);
//		if (grounded.gameObject.name == "MovingPlatform")
//						platformspeed = grounded.gameObject.GetComponent<Rigidbody2D> ().velocity.x;
//				else
//						platformspeed = 0;
//		if (grounded.gameObject.name == "Spikes")
//						gameObject.GetComponent<Pstats> ().getHit(90);
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		playerposition.x = rigidbody2D.transform.position.x;
		playerposition.y = rigidbody2D.transform.position.y;

		Pattacks attacks = GetComponent<Pattacks> ();
		//gameObject.GetComponent<Pinventory> ().spell = new Chargebolt (gameObject);
		if (move > 0 && !facingRight)
		{
			Flip ();
		}
		else if (move < 0 && facingRight)
		{
			Flip ();
		}
		if(grounded)
		{jumptime = 20000f;}
		if (jumptime == 20000 && Input.GetKeyDown(KeyCode.Space)) 
		{
						rigidbody2D.velocity = new Vector2(0,20);
			//rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		if (!grounded)
						jumptime -= 2;
	}
	void Start()
	{
		gameObject.GetComponent<Pinventory> ().spell = new MagicPeashooter(gameObject);
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
//		if(grounded)
//		{jumptime = 20000f;}
//		if (jumptime == 20000 && Input.GetKeyDown(KeyCode.Space)) 
//		{
////			rigidbody2D.velocity = new Vector2(0,50);
//			rigidbody2D.AddForce(new Vector2(0, jumpForce));
//		}
	}
}
