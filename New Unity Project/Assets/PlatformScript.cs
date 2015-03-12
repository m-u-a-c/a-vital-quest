using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public Vector2 Middleposition;
	public float speed = 5f;
	public float distance = 60f;
	public bool Left = true;
	bool Stay = false;

	void Start ()
	{
		GetComponent<BoxCollider2D> ().isTrigger = false;
	}

	void FixedUpdate ()
	{
		if (Left)
		{
			distance -= 1;
			speed = -5;
			rigidbody2D.velocity = new Vector2 (speed, 0);
			if(distance <= 0)
			{	
				StartCoroutine(StayingRight());
			}
		}
		if (!Left)
		{
			distance -= 1;
			speed = 5;
			rigidbody2D.velocity = new Vector2 (speed, 0);
			if(distance <= 0)
			{
				StartCoroutine(StayingLeft());
			}
		}
	}

	IEnumerator StayingLeft()
	{
		yield return new WaitForSeconds(1.5f);
		Left =true;
		distance = 120;
	}
	IEnumerator StayingRight()
	{
		yield return new WaitForSeconds(1.5f);
		Left =false;
		distance = 120;
	}
}
