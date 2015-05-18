using UnityEngine;
using System.Collections;

public class BarrierBehaviour : MonoBehaviour
{
    public int ticks;
    // Use this for initialization
    Timer timer;
    private GameObject light;
    void Start()
    {
        light = GameObject.Find("BarrierLight");
        GameObject.Find("Player").GetComponent<Pstats>().takedamage = false;
        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(0.1f, ticks, Tick);
        Debug.Log(ticks);
		AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().barrierActivation, gameObject.transform.position, 1f);
    }

    void Tick()
    {
        var c = gameObject.GetComponent<SpriteRenderer>();
        light.GetComponent<Light>().intensity -= 1;
        Debug.Log(c.color.a + " " + c.color.r);
        c.color = new Color(1, 1, 1, c.color.a - 0.025f);
        if (timer.ticks != ticks) return;
        GameObject.Find("Player").GetComponent<Pstats>().takedamage = true;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;
    }
}
