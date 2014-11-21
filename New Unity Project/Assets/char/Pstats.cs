using UnityEngine;
using System.Collections;

public class Pstats : MonoBehaviour {
	public float aDamage = 50;
	public float sDamage = 50;
	public float defense = 10;
	public float aSpeed = 100;
	public float health = 100;
	public float maxhealth = 100;
	//TODO: 
	public float healthreg = 0;

	public float charges = 5;
	//TODO: 
	public float chargereg = 1;
	//TODO: 
	public float critchance = 5;
	//TODO: 
	public float movement = 100;
	public bool invincible = false;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		// makes you unable to set charges above 5
		if (charges >= 5)
						charges = 5;
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
