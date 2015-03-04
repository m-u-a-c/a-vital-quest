using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public LayerMask whatIsPlayer;
	Collider2D playerAround;
	float searchRadius = 20.0f;
	public Vector2 Pos;
	float start_time = Time.timeSinceLevelLoad;
	public float cd;
	public string object_to_spawn;
	bool timer = false;
	float timeleft;
	string gospawn;
	
	public void Start()
	{

	}
	
	//Spawns an object with the specified PREFAB name that is located in the Resources/Spawner folder
	//Example:
	//GameObject go = GameObject.Find ("PFSpawner");
	//go.GetComponent<Spawner>().SpawnObject("Enemy");
	public void SpawnObject(string name)
	{
		GameObject go = (GameObject)Instantiate(Resources.Load ("Spawner/" + name));
		go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	}

	void Update()
	{
		Pos.x = transform.position.x;
		Pos.y = transform.position.y;
		playerAround = Physics2D.OverlapCircle (Pos, searchRadius, whatIsPlayer);

		timeleft -= Time.deltaTime;
		if (timeleft <= 0 && playerAround){
			timeleft = cd;
			SpawnObject(object_to_spawn);
		}
	}
}

