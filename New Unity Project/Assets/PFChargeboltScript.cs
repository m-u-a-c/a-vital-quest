﻿using UnityEngine;
using System.Collections;

public class PFChargeboltScript : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name != "Player")
			Destroy(gameObject.GetComponent("Rigidbody2D"));
	}
	
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name == "Player" && Input.GetKey(KeyCode.E)) {
			coll.gameObject.GetComponent<Pinventory>().SetSpell(new Chargebolt(coll.gameObject));
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().Pickupitem, gameObject.transform.position);
            
		}
		
	}
}
