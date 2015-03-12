using UnityEngine;
using System.Collections;

public class HolyWaterScript : MonoBehaviour {

    public float timeleft = 0.11f;
    public int ticks;
    public Sprite sprite1, sprite2;
    public bool isplaying;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().holyWater, gameObject.transform.position, 0.1f);
            if (!isplaying)
            {
                isplaying = true;
            }
            if (isplaying)
            {
                if (ticks == 0) GetComponent<SpriteRenderer>().sprite = sprite1;
                else if (ticks == 1) GetComponent<SpriteRenderer>().sprite = sprite2;
                
                timeleft -= Time.deltaTime;
                if (timeleft <= 0)
                {
                    Debug.Log("ASD", null);
                    ticks++;
                    timeleft = 0.11f;
                }
                
            }

            if (ticks < 2) return;
            var go = (GameObject)Object.Instantiate(Resources.Load("Spells/HolyWaterSphere"));
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForAnimation(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
