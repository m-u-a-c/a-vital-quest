using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {

	public float numberOfSpawners;

	Collider2D FindSpawners;
	public Transform SpawnCheck;
	public LayerMask whatIsSpawners;
	float SearchRadius = 70.0f;

	void Start () {
		numberOfSpawners = 3.0f;
	}

	void Update () {
		FindSpawners = Physics2D.OverlapCircle (transform.position, SearchRadius, whatIsSpawners);

		if (!FindSpawners)
			Application.LoadLevel (2);
	}
}
