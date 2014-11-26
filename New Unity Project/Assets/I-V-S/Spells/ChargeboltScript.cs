using UnityEngine;
using System.Collections;

public class ChargeboltScript : MonoBehaviour {

	public AudioClip chargeboltUse, chargeboltHit;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chargeboltUse, gameObject.transform.position);
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
		if (coll.gameObject.name == "Enemy") {
						coll.gameObject.GetComponent<Estats> ().getHit (GameObject.Find ("Player").GetComponent<Pinventory> ().spell.Damage);
						AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chargeboltHit, gameObject.transform.position);
				}
		Destroy (gameObject);
	}
}
