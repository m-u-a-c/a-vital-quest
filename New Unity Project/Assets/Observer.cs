﻿using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {

	Collider2D FindSpawners;
	public Transform SpawnCheck;
	public LayerMask whatIsSpawners;
	float SearchRadius = 100.0f;
	public float SpawnLimit = 0.0f;

	void Start () {
	}

	void Update () {
		FindSpawners = Physics2D.OverlapCircle (transform.position, SearchRadius, whatIsSpawners);

		if (!FindSpawners)
			StartCoroutine (StageClear ());
	}

	public void AddEnemy()
	{
		SpawnLimit += 1;
	}

	public void RemoveEnemy()
	{
		SpawnLimit -= 1;
	}

	IEnumerator StageClear()
	{
		yield return new WaitForSeconds(6);
		Application.LoadLevel (2);
	}
}
