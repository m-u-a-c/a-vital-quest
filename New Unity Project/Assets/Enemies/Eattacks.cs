using UnityEngine;
using System.Collections;

public class Eattacks : MonoBehaviour {

	Collider2D hittin;
	public Transform playercheck;
	Vector2 checkArea;
	public LayerMask whatIsPlayer;
	float Dmg;
	public float side = 1;
	public float knockbackSide;
	public bool isOnCooldown = false;



	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{



		if (gameObject.GetComponent<First_AI>().facingRight)
		{
			side = transform.position.x + 2;
		}
		if(!gameObject.GetComponent<First_AI>().facingRight)
		{
			side = transform.position.x - 2;
		}
		if (gameObject.GetComponent<First_AI>().facingRight)
		{
			knockbackSide = 0.05f;
		}
		if(!gameObject.GetComponent<First_AI>().facingRight)
		{
			knockbackSide = -0.05f;
		}
		checkArea = new Vector2(side,transform.position.y + 2);
		hittin = Physics2D.OverlapArea(transform.position, checkArea, whatIsPlayer, -Mathf.Infinity, Mathf.Infinity);

		//!hittin.gameObject.GetComponent<Pstats>().invincible
		if (hittin && !isOnCooldown)
		{
			StartCoroutine(Cooldown());
			if(hittin)
			{
				AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().meleeHit, GameObject.Find ("Player").gameObject.transform.position);
				Estats statScript = GetComponent<Estats> ();
				Dmg = statScript.aDamage;
				hittin.gameObject.GetComponent<Pstats>().getHit(Dmg);
				hittin.gameObject.GetComponent<Pstats>().rigidbody2D.AddForce(new Vector2(knockbackSide,0.05f));
				Debug.Log("Hit");
			}
		}
	}

	public IEnumerator Cooldown()
	{
		isOnCooldown = true;
		Estats statScript = GetComponent<Estats> ();
		yield return new WaitForSeconds(statScript.aSpeed);
		isOnCooldown = false;
	}
}
