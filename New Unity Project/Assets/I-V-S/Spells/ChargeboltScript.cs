using UnityEngine;
using System.Collections;

public class ChargeboltScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Vector3 vec = transform.localScale * -1;
		if (!GameObject.Find ("Player").GetComponent<Movement> ().facingRight) 
						gameObject.GetComponent<SpriteRenderer> ().transform.localScale = vec;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		float asd = GameObject.Find ("Player").GetComponent<Pinventory> ().spell.Damage;
		if (coll.gameObject.name == "Enemy")
						coll.gameObject.GetComponent<Estats> ().getHit (GameObject.Find("Player").GetComponent<Pinventory> ().spell.Damage);

		Destroy (gameObject);
	}
}
