using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChargeboltScript : MonoBehaviour {

	public AudioClip chargeboltUse, chargeboltHit;
	//public Sprite sprite0, sprite1, sprite2;
	public float changetime;
	public float timeleft;
	int sprite = 0;
	List<Sprite> sprites;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chargeboltUse, gameObject.transform.position, 0.35f);
		Vector3 vec = transform.localScale * -1;
		if (!GameObject.Find ("Player").GetComponent<Movement> ().facingRight) 
						gameObject.GetComponent<SpriteRenderer> ().transform.localScale = vec;
        GetComponent<Animation>().Play();
		//timeleft = changetime;
		//sprites = new List<Sprite> ();
        //sprites.Add (sprite0);
        //sprites.Add (sprite1);
        //sprites.Add (sprite2);
		
	}

	// Update is called once per frame
	void Update () {
        //timeleft -= Time.deltaTime;
        //if (timeleft <= 0) {
        //    timeleft = changetime;
        //    switch (sprite)
        //    {
        //    case 0:
        //        gameObject.GetComponent<SpriteRenderer>().sprite = sprite0;
        //        break;
        //    case 1:
        //        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        //        break;
        //    case 2:
        //        sprite = -1;
        //        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        //        break;
        //    }
        //    sprite++;

        //}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy")) {
						coll.gameObject.GetComponent<Estats> ().getHit (GameObject.Find ("Player").GetComponent<Pinventory> ().spells[GameObject.Find ("Player").GetComponent<Pinventory> ().selected_spell].Damage);
						
				}
		if (coll.gameObject.name != "Player") Destroy (gameObject);
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chargeboltHit,gameObject.transform.position, 0.70f);
	}
}
