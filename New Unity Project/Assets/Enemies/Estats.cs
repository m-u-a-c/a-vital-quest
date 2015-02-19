using UnityEngine;
using System.Collections;

public class Estats : MonoBehaviour {
	//hittin
	public float aDamage = 50.0f;
	public float defense = 10.0f;
	public float health = 20.0f;
	public float aSpeed = 3.0f;

	public bool isHit = false;

	void Start ()
	{
	
	}

	void Update ()
	{
		if (health <= 0) 
		{
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().enemySplat, gameObject.transform.position, 1f);
		}
	}

	public void getHit(float damageTaken)
	{
		health -= damageTaken / defense;
		StartCoroutine ("Knockbacked");
	}

	IEnumerator Knockbacked()
	{
		isHit = true;
		yield return new WaitForSeconds(0.5f);
		isHit = false;
	}
}
