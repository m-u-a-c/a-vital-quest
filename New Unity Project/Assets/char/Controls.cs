using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
	//runnin & jumpin
	public float maxSpeed = 10f;
	public float jumpForce = 4f;
	public Vector2 playerposition;	
	bool grounded = false;
	public Transform groundcheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//flippin
	bool facingRight = true;

	//killin
	Zwordstats sword = new Zwordstats();
	public float aDamage = 10.0f;
	public float sDamage = 5.0f;
	public float defense = 20.0f;
	private float health = 100.0f;
	private float charges = 5.0f;

	void Start ()
	{

	}

	void FixedUpdate ()
	{
		Zwordstats swordScript = GetComponent<Zwordstats>();
		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		playerposition.x = rigidbody2D.position.x;
		playerposition.y = rigidbody2D.position.y;

		if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();

//		if (Input.GetKeyDown (KeyCode.Mouse0))
//			swordScript.OnCollisionEnter2D ();
	}

//	void OnEnterCollision(Collision)
//	{
//
//	}

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

	void takeDamage(float damage)
	{
		health -= damage / defense;
	}
}
