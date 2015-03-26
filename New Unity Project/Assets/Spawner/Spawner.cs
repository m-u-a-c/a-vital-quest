using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public LayerMask whatIsPlayer;
	Collider2D playerAround;
	float searchRadius = 20.0f;
	public Vector2 Pos;
	//float start_time = Time.timeSinceLevelLoad;
	public float cd;
	public float limit = 10;
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
		var observeLimit = GameObject.Find ("Observer").GetComponent<Observer> ().SpawnLimit;
		Pos.x = transform.position.x;
		Pos.y = transform.position.y;
		playerAround = Physics2D.OverlapCircle (Pos, searchRadius, whatIsPlayer);

		timeleft -= Time.deltaTime;
		if (timeleft <= 0 && playerAround && observeLimit <= limit){
			timeleft = cd;

            var rnd = new System.Random();
            int i = rnd.Next(2);
            switch(i)
            {
                case 0:
                    object_to_spawn = "Enemy";
                    break;
                case 1:
                    object_to_spawn = "Caster";
                    break;
                case 2:
                    object_to_spawn = "Slime";
                    break;
                default:
                    object_to_spawn = "Enemy";
                    break;
            }

			SpawnObject(object_to_spawn);
			GameObject.Find ("Observer").GetComponent<Observer> ().AddEnemy();
		}
	}
}

