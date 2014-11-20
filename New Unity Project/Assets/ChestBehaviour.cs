using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class ChestBehaviour : MonoBehaviour {
	public bool open = false;
	enum Items {HolyGrail, FriarTucksRobe, GlassIdol, BootsOfUrgency, SturdySocks, MysticalOrb}

	void Start()
	{
		//gameObject.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (3, 3, 3);
		//gameObject.GetComponent<BoxCollider2D> ().transform.localScale = new Vector3 (1 / 3, 1 / 3, 1 / 3);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		WWW www = new WWW ("chest_open.png");
		if (open)
						return;
		if (coll.gameObject.tag != "Player")
						return;
		open = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = Sprite.Create (www.texture, new Rect(0, 0, 0, 0), new Vector2(0, 0), 100);
		
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
