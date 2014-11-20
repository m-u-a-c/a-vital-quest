using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;

	public Vector2 playerposition;
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	//flippin
	public bool facingRight = true;

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		playerposition.x = rigidbody2D.transform.position.x;
		playerposition.y = rigidbody2D.transform.position.y;

		Pattacks attacks = GetComponent<Pattacks> ();

		if (move > 0 && !facingRight)
		{
			Flip ();
		}
		else if (move < 0 && facingRight)
		{
			Flip ();
		}

		if (gameObject.GetComponent<Pstats> ().charges > 0) {
			if (Input.GetKeyDown (KeyCode.J)) {
				if (facingRight) 
				gameObject.GetComponent<Pinventory>().spell.Left = false;
				else
				gameObject.GetComponent<Pinventory>().spell.Left = true;

				gameObject.GetComponent<Pinventory> ().spell.Effect ();
				
			}		
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
