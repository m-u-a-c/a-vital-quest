using UnityEngine;
using System.Collections;

public class PeaScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var pinv = coll.gameObject.GetComponent<Pinventory>();
        if (coll.gameObject.tag == "Enemy") coll.gameObject.GetComponent<Estats>().getHit(pinv.GetSpell(typeof(MagicPeashooter)).Damage);
        Destroy(gameObject);
    }
}
