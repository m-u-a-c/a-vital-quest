using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class ChestBehaviour : MonoBehaviour {

	public LayerMask chests;
	public Transform chestCheck;
	Collider2D findChests;
	public float searchR = 0.01f;

	public Sprite chest_open;
	public bool open = false;
	public bool random = true;
	public GameObject prefab;
	System.Random rnd;
	enum Items {HolyGrail, FriarTucksRobe, GlassIdol, BootsOfUrgency, SturdySocks, MysticalOrb}

	void Start()
	{

	}

	void Update()
	{
<<<<<<< HEAD
		findChests = Physics2D.OverlapCircle (chestCheck.position, searchR, chests);

		if(findChests)
		{
			OpenSesame();
		}
	}

	public void OpenSesame()
	{
				rnd = new System.Random ();
				int i = rnd.Next (1, 5);
				if (!open) {
						gameObject.GetComponent<SpriteRenderer> ().sprite = chest_open;
						AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks> ().chestOpen, gameObject.transform.position, 0.7f);
						if (random) {
								switch (i) {
								case 1:
										SpawnItem ("PFTucksRobe");
										break;
								case 2:
										SpawnItem ("PFHolyGrail");
										break;
								case 3:
										SpawnItem ("PFChargebolt");
										break;
								case 4:
										SpawnItem ("PFMagicPeashooter");
										break;
								}
						} else {
								SpawnItem (prefab.name);
						}
						open = true;
				}
=======
		rnd = new System.Random ();
		int i = rnd.Next (1, 5);
		if (coll.gameObject.name == "Player" && !open) {
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chestOpen, gameObject.transform.position, 0.4f);
			gameObject.GetComponent<SpriteRenderer> ().sprite = chest_open;
		if (random) 
			{
			switch (i)
			{
			case 1:
				SpawnItem ("PFTucksRobe");
				break;
			case 2:
				SpawnItem ("PFHolyGrail");
				break;
			case 3:
				SpawnItem ("PFChargebolt");
				break;
			case 4:
				SpawnItem ("PFMagicPeashooter");
				break;
			}
			}
			else
			{
				SpawnItem (prefab.name);
			}
			open = true;

>>>>>>> origin/master
		}

	void OnCollisionEnter2D(Collision2D coll)
	{
//		rnd = new System.Random ();
//		int i = rnd.Next (1, 5);
//		if (coll.gameObject.name == "Player" && !open) {
//						gameObject.GetComponent<SpriteRenderer> ().sprite = chest_open;
//						AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chestOpen, gameObject.transform.position, 0.7f);
//		if (random) 
//			{
//			switch (i)
//			{
//			case 1:
//				SpawnItem ("PFTucksRobe");
//				break;
//			case 2:
//				SpawnItem ("PFHolyGrail");
//				break;
//			case 3:
//				SpawnItem ("PFChargebolt");
//				break;
//			case 4:
//				SpawnItem ("PFMagicPeashooter");
//				break;
//			}
//			}
//			else
//			{
//				SpawnItem (prefab.name);
//			}
//			open = true;
//		}

	}

	void SpawnItem(string itemname)
	{
		GameObject go = (GameObject)Instantiate(Resources.Load ("Items/" + itemname));
		go.transform.position = gameObject.transform.position;
		go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 1);
		go.rigidbody2D.AddForce(new Vector2(0, 500));
	}
}
