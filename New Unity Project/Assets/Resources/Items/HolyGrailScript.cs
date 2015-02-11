using UnityEngine;
using System.Collections;

public class HolyGrailScript : MonoBehaviour {

	public LayerMask Items;
	public Transform itemCheck;
	Collider2D findItems;
	public float searchR = 1.0f;

	void Update()
	{
		findItems = Physics2D.OverlapCircle (itemCheck.position, searchR, Items);
		if (findItems) {
		};
	}

	void FindPlayer() {
		if (Input.GetKey(KeyCode.E)) {
		
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().pickUpItem, GameObject.Find ("Player").gameObject.transform.position);
			findItems.collider.gameObject.GetComponent<Pinventory>().AddItem(new HolyGrail(findItems.collider.gameObject));
			Destroy(gameObject);
		}
	}
}
