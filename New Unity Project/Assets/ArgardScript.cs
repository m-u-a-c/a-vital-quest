using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArgardScript : MonoBehaviour {
    LayerMask layermask;
    void Start()
    {
        Debug.Log("shoot", null);
    }
	// Update is called once per frame
    List<GameObject> ignores = new List<GameObject>();
	void Update () {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.05f);
        if (hit && hit.gameObject.tag == "Enemy")
        {
            foreach (GameObject go in ignores) if (go == hit.gameObject) return;
            hit.gameObject.GetComponent<Estats>().getHit(3 + GameObject.Find("Player").GetComponent<Pstats>().sDamage * 0.8f);
            ignores.Add(hit.gameObject);
        }
        else if (hit && hit.tag != "Enemy") Destroy(gameObject);
	}
}
