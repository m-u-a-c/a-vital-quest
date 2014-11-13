using UnityEngine;
using System.Collections;

public class Pstats : MonoBehaviour {
	public float aDamage = 50.0f;
	public float sDamage = 5.0f;
	public float defense = 10.0f;
	public float aSpeed = 1.5f;
	public float health = 100.0f;
	public float charges = 5.0f;
	public bool invincible = false;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}

	public void getHit(float damageTaken)
	{
		health -= damageTaken / defense;
		Invincibility ();
		//gameObject.SendMessage ("Ja", 10);
	}

	public IEnumerator Invincibility()
	{
		invincible = true;
		yield return new WaitForSeconds(1);
		invincible = false;
	}
}
