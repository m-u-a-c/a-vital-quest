using UnityEngine;
using System.Collections;

public class PFPeaScript : MonoBehaviour {
	public float destroytime = 1;
	float timeleft;
	// Use this for initialization
	void Start () {
		timeleft = destroytime;
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().peashooterUse, gameObject.transform.position, 0.8f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeleft -= Time.deltaTime;
		if (timeleft <= 0) {
			Destroy(gameObject);
			timeleft = destroytime;
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy"))
		{
			coll.gameObject.GetComponent<Estats>().getHit(GameObject.Find("Player").GetComponent<Pinventory>().spell.Damage);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().peashooterHit, gameObject.transform.position, 0.6f);
		}
	}
}
