using UnityEngine;
using System.Collections;

public class Eattacks : MonoBehaviour {

	Collider2D hit;
	public Vector2 AIposition;
	public LayerMask whatIsPlayer;
	float Dmg;
	public float side = 1;
	public float knockbackSide;
	public bool isOnCooldown = false;

	void Start ()
	{
	
	}

	void Update ()
	{
		AIposition.x = transform.position.x;
		AIposition.y = transform.position.y;
		hit = Physics2D.OverlapCircle(AIposition, 1.0f, whatIsPlayer);

		if (hit && !isOnCooldown)
		{
			Attack();
		}
	}

	public void Attack()
	{
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().meleeHit, GameObject.Find ("Player").gameObject.transform.position);
		Estats statScript = GetComponent<Estats> ();
		Dmg = statScript.aDamage;
//		hit.gameObject.GetComponent<Pstats>().getHit(Dmg);
		hit.gameObject.GetComponent<Pstats>().rigidbody2D.AddForce(new Vector2(knockbackSide,0.05f));
		Debug.Log("Hit");
		Cooldown ();
	}

	public IEnumerator Cooldown()
	{
		isOnCooldown = true;
		Estats statScript = GetComponent<Estats> ();
		yield return new WaitForSeconds(statScript.aSpeed);
		isOnCooldown = false;
	}
}
