using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class ChestBehaviour : MonoBehaviour {
	public Sprite chest_open;
	public bool open = false;
	System.Random rnd;
	enum Items {HolyGrail, FriarTucksRobe, GlassIdol, BootsOfUrgency, SturdySocks, MysticalOrb}

	void Start()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		rnd = new System.Random ();
		int i = rnd.Next (1, 3);
		if (coll.gameObject.name == "Player" && !open) {
						gameObject.GetComponent<SpriteRenderer> ().sprite = chest_open;
		if (i == 1) SpawnItem ("PFTucksRobe");
			else SpawnItem ("PFHolyGrail");
			open = true;
		}

	}

	void SpawnItem(string itemname)
	{
		GameObject go = (GameObject)Instantiate(Resources.Load ("Items/" + itemname));
		go.transform.position = gameObject.transform.position;
		go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 1);
		go.rigidbody2D.AddForce(new Vector2(0, 500));
	}
}
