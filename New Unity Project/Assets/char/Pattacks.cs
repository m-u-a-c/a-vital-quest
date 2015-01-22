using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Pattacks : MonoBehaviour {
	
	Collider2D hittin;
	RaycastHit2D hitting;
	public Transform enemycheck;
	Vector2 checkArea;
	public LayerMask whatIsEnemy;
	public float timeleft;
	float Dmg;
	public float side = 1;
	public float knockbackSide;
	public bool isOnCooldown = false;
	public bool invincible = false;

	public AudioClip swingsound, hitsound, chargeboltHit, chargeboltUse, peashooterUse, peashooterHit, pickupitem, meleeHit, chestOpen;

	//UI
	public Image spellimage;
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay (new Vector2(gameObject.renderer.bounds.center.x, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x + 2f, gameObject.renderer.bounds.center.y - 2f));
		Gizmos.DrawRay (new Vector2(gameObject.renderer.bounds.center.x, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x - 2f, gameObject.renderer.bounds.center.y - 2f));
	}
	void Start ()
	{
		
	}

	void FixedUpdate ()
	{
		timeleft -= Time.deltaTime;

		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			switch (gameObject.GetComponent<Movement>().facingRight)
			{
			case true:
				hitting = Physics2D.Raycast(new Vector2(gameObject.renderer.bounds.center.x, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x + 2f, gameObject.renderer.bounds.center.y - 2));
				break;
			case false:
				hitting = Physics2D.Raycast(new Vector2(gameObject.renderer.bounds.center.x, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x - 2f, gameObject.renderer.bounds.center.y - 2));
				break;
			}
		}

		if (hitting && hitting.collider.gameObject.tag == "Enemy") {
			hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage);
			hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide,0.05f));
			AudioSource.PlayClipAtPoint (hitsound, gameObject.transform.position);
			Debug.Log("Hit");
			
		}

		if (gameObject.GetComponent<Movement>().facingRight)
		{
			side = transform.position.x + 2;
		}
		if(!gameObject.GetComponent<Movement>().facingRight)
		{
			side = transform.position.x - 2;
		}
		if (gameObject.GetComponent<Movement>().facingRight)
		{
			knockbackSide = 0.05f;
		}
		if(!gameObject.GetComponent<Movement>().facingRight)
		{
			knockbackSide = -0.05f;
		}
		checkArea = new Vector2(side,transform.position.y + 2);
		hittin = Physics2D.OverlapArea(transform.position, checkArea, whatIsEnemy, -Mathf.Infinity, Mathf.Infinity);

		if (Input.GetKeyDown (KeyCode.Mouse0))
						AudioSource.PlayClipAtPoint (swingsound, gameObject.transform.position, 0.6f);

//		if (Input.GetKey (KeyCode.Mouse0) && hittin && !isOnCooldown)
//		{
//
//			StartCoroutine(Cooldown());
//			if(hittin)
//			{
//				if (hittin.tag == "Enemy") );
//			}
//		}

		if (gameObject.GetComponent<Pstats> ().charges > 0 && timeleft <= 0 && Input.GetKeyUp (KeyCode.Q)) {
			timeleft = gameObject.GetComponent<Pinventory>().spell.Cooldown;	

				var spell = gameObject.GetComponent<Pinventory>().spell;
				if (gameObject.GetComponent<Movement>().facingRight)
				{
					gameObject.GetComponent<Pinventory>().spell.Left = false;
				}
				else
					gameObject.GetComponent<Pinventory>().spell.Left = true;

				if (gameObject.GetComponent<Pinventory>().spell.Cost <= gameObject.GetComponent<Pstats>().charges)
				gameObject.GetComponent<Pinventory> ().spell.Effect ();
		}
	}

	public IEnumerator Cooldown()
	{
		isOnCooldown = true;
		Pstats statScript = GetComponent<Pstats> ();
		yield return new WaitForSeconds(statScript.aSpeed);
		isOnCooldown = false;
	}
}
