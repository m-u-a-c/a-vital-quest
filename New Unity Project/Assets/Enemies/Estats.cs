using UnityEngine;
using System.Collections;

public class Estats : MonoBehaviour {
	//hittin
	public float aDamage = 5.0f;
	public float defense = 10.0f;
	public float health = 20.0f;

	void Start ()
	{
	
	}

	void Update ()
	{
		if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}

	public void getHit(float damageTaken)
	{
		health -= damageTaken / defense;
		//gameObject.SendMessage ("Ja", 10);
	}
}
