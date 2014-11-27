using UnityEngine;
using System.Collections;

public class PFMagicPeashooterScript : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name != "Player")
			Destroy(gameObject.GetComponent("Rigidbody2D"));
	}
	
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name == "Player" && Input.GetKey(KeyCode.E)) {
			coll.gameObject.GetComponent<Pinventory>().spell = new MagicPeashooter(coll.gameObject);
			Destroy(gameObject);
		}
		
	}
}
