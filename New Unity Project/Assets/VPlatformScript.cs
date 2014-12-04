using UnityEngine;
using System.Collections;

public class VPlatformScript : MonoBehaviour {

	public Vector2 Middleposition;
	public float speed = 5f;
	public float distance = 50f;
	public bool Up = true;
	
	void Start ()
	{
		GetComponent<BoxCollider2D> ().isTrigger = false;
	}
	
	void FixedUpdate ()
	{
		if (Up)
		{
			distance -= 1;
			speed = 5;
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, speed);
			if(distance <= 0)
			{
				Up =false;
				distance = 140;
			}
		}
		if (!Up)
		{
			distance -= 1;
			speed = -5;
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, speed);
			if(distance <= 0)
			{
				Up =true;
				distance = 140;
			}
		}
	}
}
