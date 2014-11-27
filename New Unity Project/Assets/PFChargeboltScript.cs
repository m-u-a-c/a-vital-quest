using UnityEngine;
using System.Collections;

public class PFChargeboltScript : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name != "Player")
			Destroy(gameObject.GetComponent("Rigidbody2D"));
	}
	
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name == "Player" && Input.GetKey(KeyCode.E)) {
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().Pickupitem, GameObject.Find ("Player").gameObject.transform.position);
			coll.gameObject.GetComponent<Pinventory>().spell = new Chargebolt(coll.gameObject);
			Destroy(gameObject);
		}
		
	}
}
