using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public Vector2 Middleposition;
	public float speed = 5f;
	public float distance = 60f;
	public bool Left = true;

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
				Left =false;
				distance = 120;
			}
		}
		if (!Left)
		{
			distance -= 1;
			speed = 5;
			rigidbody2D.velocity = new Vector2 (speed, 0);
			if(distance <= 0)
			{
				Left =true;
				distance = 120;
			}
		}
	}
}
