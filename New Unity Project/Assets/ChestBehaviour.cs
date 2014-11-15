using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class ChestBehaviour : MonoBehaviour {

	enum Items {HolyGrail, FriarTucksRobe, GlassIdol, BootsOfUrgency, SturdySocks, MysticalOrb}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Player")
						return;
		SpawnItem ("PFHolyGrail");

	}

	void SpawnItem(string itemname)
	{
		GameObject go = (GameObject)Instantiate(Resources.Load ("Items/" + itemname));
		go.transform.position = gameObject.transform.position;
		go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 1);
		go.rigidbody2D.AddForce(new Vector2(0, 500));
	}
}
