using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public Vector2 Middleposition;
	public float speed = 5f;
	public float distance = 80f;
	public bool Left = true;
	public bool Stay = false;

	void Start ()
	{
		GetComponent<BoxCollider2D> ().isTrigger = false;
	}

	void FixedUpdate ()
	{
		if (Left && !Stay)
		{
			distance -= 1;
			speed = -5;
			rigidbody2D.velocity = new Vector2 (speed, 0);
			if(distance <= 0)
			{	
				Stay = true;
				StartCoroutine(StayingRight());
			}
		}
		if (!Left && !Stay)
		{
			distance -= 1;
			speed = 5;
			rigidbody2D.velocity = new Vector2 (speed, 0);
			if(distance <= 0)
			{
				Stay = true;
				StartCoroutine(StayingLeft());
			}
		}
	}

	IEnumerator StayingLeft()
	{
		rigidbody2D.velocity = new Vector2 (0, 0);
		yield return new WaitForSeconds(1.5f);
		Left =true;
		Stay = false;
		distance = 80f;
	}
	IEnumerator StayingRight()
	{
		rigidbody2D.velocity = new Vector2 (0, 0);
		yield return new WaitForSeconds(1.5f);
		Left =false;
		Stay = false;
		distance = 80f;
	}
}
