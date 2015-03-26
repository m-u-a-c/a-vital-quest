using UnityEngine;
using System.Collections;

public class PeaScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().peashooterUse, gameObject.transform.position, 0.60f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var pinv = GameObject.Find("Player").gameObject.GetComponent<Pinventory>();
        if (coll.gameObject.tag == "Enemy") coll.gameObject.GetComponent<Estats>().getHit(pinv.GetSpell(typeof(MagicPeashooter)).Damage);
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().peashooterHit, gameObject.transform.position, 0.30f);
        Destroy(gameObject);
    }
}
