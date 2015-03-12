using UnityEngine;
using System.Collections;

public class TabletScript : MonoBehaviour {

	public Collider2D coll1;
	public float timeleft;
	public float ticktime = 0.1f;
	public int ticks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			if (ticks >= 1) Destroy(gameObject);
			
			bool damage = false;
			timeleft -= Time.deltaTime;
			if (timeleft <= 0)
			{
				timeleft = ticktime;
				damage = true;
				ticks++;
			}



		coll1 = Physics2D.OverlapArea (new Vector2 (GameObject.Find ("Player").transform.position.x, 
		                                            GameObject.Find ("Player").GetComponent<BoxCollider2D> ().bounds.extents.y), 
		                               new Vector2 (GameObject.Find ("Player").transform.position.x + 1f, 
		            								GameObject.Find ("Player").GetComponent<BoxCollider2D> ().bounds.extents.y - GameObject.Find ("Player").GetComponent<BoxCollider2D> ().bounds.size.y));
		if (coll1 && coll1.gameObject.tag == "Enemy" && damage)
		{
			coll1.gameObject.GetComponent<Estats>().getHit(GameObject.Find("Player").GetComponent<Pstats>().aDamage);
		}
	}
}
