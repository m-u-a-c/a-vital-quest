using UnityEngine;
using System.Collections;

public class BloodboltScript : MonoBehaviour {

    int Damage = 20;
    Timer timer;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(1, 5, () => { if (timer.ticks == 5) Destroy(gameObject); });
	}
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") 
		{
			coll.gameObject.GetComponent<Pstats> ().getHit (Damage, GameObject.Find ("Caster"));
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().casterHit, gameObject.transform.position);
		}
        Destroy(gameObject);

    }
}
