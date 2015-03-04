using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    
    public float destroytime = 3;
    float timeleft;
    // Use this for initialization
    void Start()
    {
        timeleft = destroytime;
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().yaosShieldUse,gameObject.transform.position, 0.5f);
        
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name.Contains("Enemy")) {
//			coll.gameObject.GetComponent<Estats> ().getHit (GameObject.Find ("Player").GetComponent<Pinventory> ().spell.Damage);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().yaosShieldHit,gameObject.transform.position, 0.35f);
		}

	}
    // Update is called once per frame
    void FixedUpdate()
    {
        


        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            Destroy(gameObject);
            timeleft = destroytime;
        }
    }
}
