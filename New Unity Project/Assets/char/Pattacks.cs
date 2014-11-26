using UnityEngine;
using System.Collections;

public class Pattacks : MonoBehaviour {
	
	Collider2D hittin;
	public Transform enemycheck;
	Vector2 checkArea;
	public LayerMask whatIsEnemy;
	float Dmg;
	public float side = 1;
	public float knockbackSide;
	public bool isOnCooldown = false;
	public bool invincible = false;

	void Start ()
	{
		
	}

	void FixedUpdate ()
	{
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

		if (Input.GetKey (KeyCode.Mouse0) && hittin && !isOnCooldown)
		{
			StartCoroutine(Cooldown());
			if(hittin)
			{
				Pstats statScript = GetComponent<Pstats> ();
				Zwordstats swordScript = GetComponent<Zwordstats> ();
				Dmg = statScript.aDamage;
				hittin.gameObject.GetComponent<Estats>().getHit(Dmg);
				if (hittin.tag == "Enemy") hittin.gameObject.GetComponent<Estats>().rigidbody2D.AddForce(new Vector2(knockbackSide,0.05f));
				Debug.Log("Hit");
			}
		}

		if (gameObject.GetComponent<Pstats> ().charges > 0) {
			if (Input.GetKeyDown (KeyCode.J)) {
				var spell = gameObject.GetComponent<Pinventory>().spell;
				if (gameObject.GetComponent<Movement>().facingRight)
				{
					gameObject.GetComponent<Pinventory>().spell.Left = false;
				}
				else
					gameObject.GetComponent<Pinventory>().spell.Left = true;
				
				gameObject.GetComponent<Pinventory> ().spell.Effect ();
			}		
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
