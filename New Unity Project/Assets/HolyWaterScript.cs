using UnityEngine;
using System.Collections;

public class HolyWaterScript : MonoBehaviour {

    public Sprite sprite1, sprite2;
    Timer timer;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Tick()
    {
        if (timer.ticks == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (timer.ticks == 2)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
            timer = gameObject.AddComponent<Timer>();
            timer.SetTimer(0.025f, 2, new System.Action(Tick));
        }
    }

    IEnumerator WaitForAnimation(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
