using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public LayerMask enemies;
	Timer timer;
	float yscale;
	// Use this for initialization
	void Start () {
		timer = gameObject.AddComponent<Timer> ();
		timer.SetTimer (0.05f, 10, new System.Action(Tick));
		yscale  = gameObject.transform.localScale.x;
	}
	void Tick()
	{
		if (timer.ticks == 1)
						DoDamage ();
		if (timer.ticks == 10)
						Destroy (gameObject);
		gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x, yscale - (0.1f * timer.ticks * yscale), gameObject.transform.localScale.y);
	}

	void DoDamage()
	{
		var pstats = GameObject.Find ("Player").GetComponent<Pstats> ();
		var bounds = gameObject.renderer.bounds.center;
		var pos = gameObject.transform.position;
		var hit = Physics2D.OverlapAreaAll (new Vector2 (pos.x - bounds.x / 2, pos.y + bounds.y / 2), new Vector2 (pos.x + bounds.x / 2, pos.y - bounds.y / 2), LayerMask.GetMask("Enemies"));
		if (hit.Length > 0)
			foreach (Collider2D coll in hit)
				{
					coll.gameObject.GetComponent<Estats>().getHit((pstats.sDamage * 2) + 3, false);
				}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
