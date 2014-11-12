using UnityEngine;
using System.Collections;

public class Pattacks : MonoBehaviour {
	
	Collider2D hittin;
	public Transform enemycheck;
	Vector2 checkArea;
	public LayerMask whatIsEnemy;
	float Dmg;

	void Start ()
	{
		
	}

	void FixedUpdate ()
	{
		checkArea = new Vector2(transform.position.x + 2,transform.position.y + 4);
		hittin = Physics2D.OverlapArea(transform.position, checkArea, whatIsEnemy, -Mathf.Infinity, Mathf.Infinity);

		//ska inkludera && hittin
		if (Input.GetKey (KeyCode.Mouse0) && hittin)
		{
			Pstats statScript = GetComponent<Pstats> ();

			Zwordstats swordScript = GetComponent<Zwordstats> ();
			//skapar errors
			//Dmg = statScript.aDamage;
			Dmg = statScript.aDamage;
			hittin.gameObject.GetComponent<Estats>().getHit(Dmg);
			//enemyScript.health =- Dmg;
		}
	}
}
