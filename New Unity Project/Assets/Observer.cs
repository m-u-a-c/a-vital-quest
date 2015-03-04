using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {

	Collider2D FindSpawners;
	public Transform SpawnCheck;
	public LayerMask whatIsSpawners;
	float SearchRadius = 100.0f;

	void Start () {
	}

	void Update () {
		FindSpawners = Physics2D.OverlapCircle (transform.position, SearchRadius, whatIsSpawners);

		if (!FindSpawners)
			Application.LoadLevel (2);
	}
}
