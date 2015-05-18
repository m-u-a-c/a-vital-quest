using UnityEngine;
using System.Collections;

public class Flying_AI : MonoBehaviour {

	public float enemySpeed = 4f;
	private GameObject player;
	Collider2D playerAround;
	public LayerMask whatIsPlayer;
	float searchRadius = 15.0f;
	Vector2 FAIPosition;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void FixedUpdate ()
	{
		FAIPosition.x = transform.position.x;
		FAIPosition.y = transform.position.y;
		playerAround = Physics2D.OverlapCircle (FAIPosition, searchRadius, whatIsPlayer);

		if (playerAround)
						Flight ();
	}

	void Flight()
	{
		if (player.transform.position.x > transform.position.x) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (player.transform.position.x < transform.position.x)
		{	
			GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed * -1, GetComponent<Rigidbody2D>().velocity.y);
//			transform.position.x -= (enemySpeed/1000);
		}
		if (player.transform.position.y > transform.position.y) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, enemySpeed);
		}
		if (player.transform.position.y < transform.position.y)
		{	
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, enemySpeed * -1);
		}
	}
}
