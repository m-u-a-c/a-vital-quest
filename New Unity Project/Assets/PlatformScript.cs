using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    public float speed = 0.05f;
    public float leftx, rightx;
    public bool Right = true;
    public bool Stay = false;
    public float Staytime;
    Timer staytimer;
    Timer movetimer;

    void OnCollisionExit2D(Collision2D coll)
    {
        coll.gameObject.transform.parent = null;
    }

    void MoveRight()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, -1);
    }

    void MoveLeft()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, -1);
    }

    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        staytimer = gameObject.AddComponent<Timer>();
        movetimer = gameObject.AddComponent<Timer>();
        staytimer.SetTimer(Staytime, 1, () =>
        {
            if (Right) MoveRight();
            else MoveLeft();
        });
        staytimer.StopTimer();
        movetimer.SetTimer(0.01f, 0, () =>
        {
            if (staytimer.running) return;
            if (Right) MoveRight();
            else MoveLeft();

        });

    }

    void Update()
    {
        if (gameObject.transform.position.x >= rightx || gameObject.transform.position.x <= leftx)
        {
            staytimer.StartTimer();
            Right = gameObject.transform.position.x >= rightx ? false : true;
        }

    }
  
}
