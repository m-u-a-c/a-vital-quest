﻿using UnityEngine;
using System.Collections;

public class Estats : MonoBehaviour {
	//hittin
	public float aDamage = 10.0f;
	public float health = 20.0f;
	public float aSpeed = 3.0f;

	public bool isHit = false;

	void Start ()
	{
	
	}

	void Update ()
	{
		if (health <= 0) 
		{
			GameObject.Find ("Observer").GetComponent<Observer> ().RemoveEnemy();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().enemySplat, gameObject.transform.position, 0.15f);
		}
	}

	public int getHit(float damageTaken, bool knockback = true)
	{
		health -= damageTaken;
		if (knockback) StartCoroutine ("Knockbacked");
	    return gameObject.GetInstanceID();
	}

	IEnumerator Knockbacked()
	{
		isHit = true;
		yield return new WaitForSeconds(0.5f);
		isHit = false;
	}
}
