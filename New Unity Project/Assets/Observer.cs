using UnityEngine;
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
		{
			GameObject.Find ("WinScreen").GetComponent<Clear> ().Show();
			StartCoroutine (StageClear ());
		}
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
        var oldvars = GameObject.Find("SavedVars").GetComponent<SavedVars>();
	    var inv = GameObject.Find("Player").GetComponent<Pinventory>();
	    oldvars.ClassItem = inv.ClassItem;
	    oldvars.items = inv.items;
	    oldvars.spells = inv.spells;
        Application.LoadLevel (2);

	}
}
