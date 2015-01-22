using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 50f;
	public float jumptime = 20000f;

	
    
	public Vector2 playerposition;
	Collider2D grounded;
	public Transform groundcheck;
	float groundRadius = 0.24f;
	public LayerMask whatIsGround;
    float last_yvel = 0;
    float last_xvel = 0;
	public float platformspeed = 0;
	
	//flipping
	public bool facingRight = true;

	bool moving = false;
	public float speed;

	void FixedUpdate ()
	{
        if (gameObject.GetComponent<Pattacks>().swinging) gameObject.GetComponent<Animator>().SetInteger("Direction", 4);
        else if (Mathf.Abs(rigidbody2D.velocity.x) <= 2 && rigidbody2D.velocity.y <= 2 && grounded) gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
        else
        {
            if (rigidbody2D.velocity.y > 0 && !grounded) gameObject.GetComponent<Animator>().SetInteger("Direction", 0);
            else if (rigidbody2D.velocity.y < 0 && !grounded) gameObject.GetComponent<Animator>().SetInteger("Direction", 2);
            else if (Mathf.Abs(rigidbody2D.velocity.x) > 0 && grounded) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
        }
       


       

		speed = gameObject.rigidbody2D.velocity.x;
		moving = !(Mathf.Abs(gameObject.rigidbody2D.velocity.x) < 3);
     
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

        //Always last:
        last_xvel = Mathf.Abs(gameObject.rigidbody2D.velocity.x);
        last_yvel = gameObject.rigidbody2D.velocity.y;
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
