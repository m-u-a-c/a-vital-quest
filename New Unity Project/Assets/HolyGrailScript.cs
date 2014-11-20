using UnityEngine;
using System.Collections;

public class HolyGrailScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name != "Player")
			Destroy(gameObject.GetComponent("Rigidbody2D"));
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name == "Player" && Input.GetKey(KeyCode.E)) {
			coll.gameObject.GetComponent<Pinventory>().AddItem(new HolyGrail(coll.gameObject));
			Destroy(gameObject);
		}

		}
}
