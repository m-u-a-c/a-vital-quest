﻿using UnityEngine;
using System.Collections;

public class Slime_AI : MonoBehaviour {

	public float enemySpeed = 4.0f;
	public float jumpForce = 4.0f;
	public Vector2 AIposition;
	public bool facingRight = false;
	
	private GameObject player;
	
	Collider2D playerAround;
	Collider2D attackRange;
	public LayerMask whatIsPlayer;
	public LayerMask whatIsGround;
	float searchRadius = 10.0f;
	float blockRadius = 0.1f;
	
	Collider2D groundAroundLB;
	Collider2D groundAroundRB;
	Collider2D groundAroundRU;
	Collider2D groundAroundLU;
	
	public Transform blockCheckRB;
	public Transform blockCheckLB;
	public Transform blockCheckRU;
	public Transform blockCheckLU;
	
	void Start ()
	{
        player = GameObject.Find("Player");

        //if (facingRight)
        //    Flip ();
        //else if (!facingRight)
        //    Flip ();
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
        if (player.transform.position.x > transform.position.x && facingRight)
        {
            Flip();
        }
        if (player.transform.position.x < transform.position.x && !facingRight)
        {
            Flip();
        }
    }

	void FixedUpdate ()
	{

       
		
		AIposition.x = transform.position.x;
		AIposition.y = transform.position.y;

		attackRange = Physics2D.OverlapCircle (AIposition, 0.1f, whatIsPlayer);
		playerAround = Physics2D.OverlapCircle (AIposition, searchRadius, whatIsPlayer);
		groundAroundLB = Physics2D.OverlapCircle (blockCheckLB.position, blockRadius, whatIsGround);
		groundAroundRB = Physics2D.OverlapCircle (blockCheckRB.position, blockRadius, whatIsGround);
		groundAroundRU = Physics2D.OverlapCircle (blockCheckRU.position, blockRadius, whatIsGround);
		groundAroundLU = Physics2D.OverlapCircle (blockCheckLU.position, blockRadius, whatIsGround);

		Estats statScript = GetComponent<Estats> ();

		if (!statScript.isHit && playerAround)
		{
			EMovement ();
		}
		
/*		if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
		else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
		
		if (Mathf.Abs(gameObject.rigidbody2D.velocity.x) > 2) gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
		else gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
*/
	}
	
	void EMovement()
	{
		if (attackRange) {
						GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
				} else {
						if (player.transform.position.x > transform.position.x && groundAroundRU && !groundAroundRB) {
								GetComponent<Rigidbody2D>().velocity = new Vector2 (enemySpeed / 3, GetComponent<Rigidbody2D>().velocity.y);
						}
						if (player.transform.position.x < transform.position.x && groundAroundLU && !groundAroundLB) {	
								GetComponent<Rigidbody2D>().velocity = new Vector2 ((enemySpeed / 3) * -1, GetComponent<Rigidbody2D>().velocity.y);
						}
				}
	}
}
