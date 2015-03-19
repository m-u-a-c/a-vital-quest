using UnityEngine;
using System.Collections;

public class VPlatformScript : MonoBehaviour {

	public Vector2 Middleposition;
	public float speed = 5f;
	public float distance = 80f;
	public bool Up = true;
	public bool Stay = false;
	
	void Start ()
	{
		GetComponent<BoxCollider2D> ().isTrigger = false;
	}
	
	void FixedUpdate ()
	{
		if (Up && !Stay)
		{
			distance -= 1;
			speed = 5;
			rigidbody2D.velocity = new Vector2 (0, speed);
			if(distance <= 0)
			{
				Stay = true;
				StartCoroutine(StayingUp());
			}
		}
		if (!Up && !Stay)
		{
			distance -= 1;
			speed = -5;
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, speed);
			if(distance <= 0)
			{
				Stay = true;
				StartCoroutine(StayingDown());
			}
		}
	}

	IEnumerator StayingDown()
	{
		rigidbody2D.velocity = new Vector2 (0, 0);
		yield return new WaitForSeconds(1.5f);
		Up =true;
		Stay = false;
		distance = 80f;
	}
	IEnumerator StayingUp()
	{
		rigidbody2D.velocity = new Vector2 (0, 0);
		yield return new WaitForSeconds(1.5f);
		Up =false;
		Stay = false;
		distance = 80f;
	}
}
