using UnityEngine;
using System.Collections;

public class HolyWaterSphereScript : MonoBehaviour {

    public Collider2D coll;
    public float timeleft;
    public float ticktime = 0.5f;
    public int ticks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ticks >= 6) Destroy(gameObject);

        bool damage = false;
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            timeleft = ticktime;
            damage = true;
            ticks++;
        }

        coll = Physics2D.OverlapCircle(transform.position, 2);
        if (coll && coll.gameObject.tag == "Enemy" && damage)
        {
            coll.gameObject.GetComponent<Estats>().getHit(GameObject.Find("Player").GetComponent<Pstats>().sDamage * 0.6f);
        }
	}

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, 2);
    }
}
