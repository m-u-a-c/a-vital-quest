using UnityEngine;
using System.Collections;

public class Pstats : MonoBehaviour {
	public float aDamage = 50.0f;
	public float sDamage = 5.0f;
	public float defense = 10.0f;
	public float aSpeed = 100;
	public float health = 100.0f;
	//TODO: 
	public float healthreg = 0;
	// makes you unable to set charges above 5
	public float charges { get{ return charges; } set{if (charges > 5) charges = 5; return;} }
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
