using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float health = 20;

	//Spawns an object with the specified PREFAB name that is located in the Resources/Spawner folder
	//Example:
	//GameObject go = GameObject.Find ("PFSpawner");
	//go.GetComponent<Spawner>().SpawnObject("Enemy");
	public void SpawnObject(string name)
	{
		GameObject go = (GameObject)Instantiate(Resources.Load ("Spawner/" + name));
		go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	}
	float start_time = Time.timeSinceLevelLoad;
	float cd;
	bool timer = false;
	string gospawn;
	public void SetTimer(string name, float interval)
	{
		gospawn = name;
		cd = interval;
		timer = true;
	}
	public void DeactivateTimer()
	{
		timer = false;
		}
	void Update()
	{
		if (!timer)
						return;
		if (Time.timeSinceLevelLoad - start_time > cd) {
			SpawnObject(gospawn);
			start_time = Time.timeSinceLevelLoad;

		}
	}
}
