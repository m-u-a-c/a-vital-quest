using UnityEngine;
using System.Collections;

public class VPlatformScript : MonoBehaviour
{
    public float speed = 0.05f;
    public bool Up = true;
    // public bool Stay = false;
    public float topy = 0, boty = 0;
    Timer staytimer;
    Timer movetimer;
    public float Staytime;

    void OnCollisionExit2D(Collision2D coll)
    {
        coll.gameObject.transform.parent = null;
    }
    void MoveUp()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, -1);
    }

    void MoveDown()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, -1);
    }

    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        staytimer = gameObject.AddComponent<Timer>();
        movetimer = gameObject.AddComponent<Timer>();
        staytimer.SetTimer(Staytime, 1, () =>
            {
                if (Up) MoveUp();
                else MoveDown();
            });
        staytimer.StopTimer();
        movetimer.SetTimer(0.0001f, 0, () =>
            {
                if (staytimer.running) return;
                if (Up) MoveUp();
                else MoveDown();

            });

    }

    void Update()
    {
        if (gameObject.transform.position.y >= topy || gameObject.transform.position.y <= boty)
        {
            staytimer.StartTimer();
            Up = gameObject.transform.position.y >= topy ? false : true;
        }

    }
}
