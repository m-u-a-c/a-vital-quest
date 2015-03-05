using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pstats : MonoBehaviour {
	public float aDamage = 50;
	public float sDamage = 50;
	public float defense = 2;
	public float aSpeed = 100;
	public float health = 100;
	public float maxhealth = 100;
	//TODO: 
	public float healthreg = 0;

	public float charges = 5;
	//TODO: 
	public float chargereg = 1;
	//TODO: 
	public float critchance = 0.05f;
	//TODO: 
    public float movement = 1;
	public bool invincible = false;

	//UI
	public Slider healthbar;
	public Slider chargeslider;
	
	public float timeleft = 1;
	public float invincibilitytimer = 5.0f;

	void Start ()
	{
		timeleft = chargereg;
	}

	void Update ()
	{
		timeleft -= Time.deltaTime;
		if (timeleft <= 0) {
			charges++;
			timeleft = chargereg;
		}
		// makes you unable to set charges above 5
		if (charges >= 5)
						charges = 5;
		if (health <= 0) 
		{
			Destroy(gameObject);
			Application.LoadLevel(2);
		}
		chargeslider.value = charges;
        healthbar.value = health;

	}

	void FixedUpdate()
	{

	}


	public void getHit(float damageTaken)
	{
		if(invincible == false)
		{
		health -= damageTaken;
		healthbar.value = health;
			StartCoroutine("Invincibility");
		}
	}

	IEnumerator Invincibility()
	{
		invincible = true;
		yield return new WaitForSeconds(invincibilitytimer);
		invincible = false;
	}

	

}
