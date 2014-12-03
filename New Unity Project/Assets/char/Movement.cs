using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;

	public Sprite run0, run1, run2, run3, standing0, jumping0, jumping1;

	public Vector2 playerposition;
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	//flippin
	public bool facingRight = true;

	public float changetime, changetime_jump;
	public float timeleft, timeleft_jump;
	bool moving = false;
	int runsprite = 0, jumpsprite = 0;
	bool wayback = true;
	public float speed;
	void FixedUpdate ()
	{

		speed = gameObject.rigidbody2D.velocity.x;
		moving = !(Mathf.Abs(gameObject.rigidbody2D.velocity.x) < 3);
		timeleft -= Time.deltaTime;
		timeleft_jump -= Time.deltaTime;
		if (timeleft_jump <= 0 && !grounded && gameObject.rigidbody2D.velocity.y > 0) {
			timeleft_jump = changetime_jump;
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
				} else if (!moving)
						gameObject.GetComponent<SpriteRenderer> ().sprite = standing0;

		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

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
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
