using UnityEngine;
using System.Collections;

public class PFChargeboltScript : MonoBehaviour {
	
	public LayerMask Items;
	public Transform itemCheck;
	Collider2D findItems;
	public float searchR = 1.0f;
	
	void Update()
	{
		findItems = Physics2D.OverlapCircle (itemCheck.position, searchR, Items);
		if (findItems) {
			FindPlayer();
		};
	}
	

	void FindPlayer() {
				if (Input.GetKey (KeyCode.E)) {
                        AudioSource.PlayClipAtPoint (GameObject.Find("Player").GetComponent<Pattacks>().pickUpItem, GameObject.Find("Player").gameObject.transform.position);
			
//						findItems.gameObject.GetComponent<Pinventory> ().SetSpell (new Chargebolt (findItems.gameObject));
				}
		}
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name == "Player" && Input.GetKey(KeyCode.E)) {
           		
            coll.gameObject.GetComponent<Pinventory>().AddSpell(new Chargebolt(coll.gameObject));
			Destroy(gameObject);
		}
	}
}
