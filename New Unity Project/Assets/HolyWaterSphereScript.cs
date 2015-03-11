using UnityEngine;
using System.Collections;

public class HolyWaterSphereScript : MonoBehaviour {

    public Collider2D[] coll;
    Timer timer;

	// Use this for initialization
	void Start () {
        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(0.5f, 6);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Tick()
    {
        coll = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach(Collider2D c in coll)
        {
            if (c && c.gameObject.tag == "Enemy")
            {
                c.gameObject.GetComponent<Estats>().getHit(GameObject.Find("Player").GetComponent<Pstats>().sDamage * 0.6f);
            }
        }
       
    }

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, 2);
    }
}
