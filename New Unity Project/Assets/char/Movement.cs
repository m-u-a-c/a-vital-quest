using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 50f;
	public float jumptime = 20000f;

	
	public bool lastframegrounded;
	public Vector2 playerposition;
	public Collider2D grounded;
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
		GameObject.Find ("Landing").transform.position = gameObject.transform.position;
		if (last_yvel < 0 && grounded && !GameObject.Find ("Landing").GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find ("Landing").GetComponent<AudioSource>().Play();
		}	

		//if (grounded && !lastframegrounded) 
		//	AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().landing, gameObject.transform.position, 1f);

		if (Mathf.Abs(rigidbody2D.velocity.x) >= 1 && grounded && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			gameObject.GetComponent<AudioSource>().Play();
		}
		if ((!grounded) || Mathf.Abs(rigidbody2D.velocity.x) < 1) 
			gameObject.GetComponent<AudioSource>().Pause();

        if (gameObject.GetComponent<Pattacks>().swinging) gameObject.GetComponent<Animator>().SetInteger("Direction", 4);
        else if (Mathf.Abs(rigidbody2D.velocity.x) <= 2 && rigidbody2D.velocity.y <= 2 && grounded) gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
        else
        {
            if (rigidbody2D.velocity.y > 0 && !grounded) 
			{ 
				gameObject.GetComponent<Animator>().SetInteger("Direction", 0);

			}
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

        //Always last:
		last_yvel = (gameObject.rigidbody2D.velocity.y);
        last_xvel = Mathf.Abs(gameObject.rigidbody2D.velocity.x); 
        
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
//			rigidbody2D.velocity = new Vector2(0,50);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
}
