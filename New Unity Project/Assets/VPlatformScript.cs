using UnityEngine;
using System.Collections;

public class VPlatformScript : MonoBehaviour
{

    public Vector2 Middleposition;
    public float speed = 5f;
    public float distance = 80f;
    public bool Up = true;
    public bool Stay = false;
    public float topy = 0, boty = 0;
    Timer uptimer;
    Timer downtimer;
    Timer staytimer;


    void Start()
    {
        //GetComponent<BoxCollider2D>().isTrigger = false;
        //uptimer = gameObject.AddComponent<Timer>();
        //downtimer = gameObject.AddComponent<Timer>();
        //staytimer = gameObject.AddComponent<Timer>();
        //uptimer.SetTimer(0.01f, 0, () =>
        //    {
        //        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f);
        //    });
        //downtimer.SetTimer(0.01f, 0, () =>
        //{
        //    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f);
        //});
        //staytimer.SetTimer(3, 1, () =>
        //{
        //    Stay = false;
        //    Up = !Up;
        //});
        //staytimer.StopTimer();
        //downtimer.StopTimer();


    }

    void Update()
    {
        //if (Stay) return;
        //if (Up && gameObject.transform.position.y >= topy)
        //{
        //    Stay = true;
        //    staytimer.StartTimer();
        //    Up = false;
        //}
        //if (!Up && gameObject.transform.position.y <= boty)
        //{
        //    Stay = true;
        //    staytimer.StartTimer();
        //    Up = true;
        //}
        //if (Up && topy > gameObject.transform.position.y)
        //{
        //    uptimer.StartTimer();
        //}
        //if (!Up && boty < gameObject.transform.position.y)
        //{
        //    downtimer.StartTimer();
        //}
    }

    void FixedUpdate()
    {
        if (Up && !Stay)
        {
            distance -= 1;
            speed = 5;
            rigidbody2D.velocity = new Vector2(0, speed);
            if (distance <= 0)
            {
                Stay = true;
                StartCoroutine(StayingUp());
            }
        }
        if (!Up && !Stay)
        {
            distance -= 1;
            speed = -5;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
            if (distance <= 0)
            {
                Stay = true;
                StartCoroutine(StayingDown());
            }
        }
    }

    IEnumerator StayingDown()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1.5f);
        Up = true;
        Stay = false;
        distance = 80f;
    }
    IEnumerator StayingUp()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1.5f);
        Up = false;
        Stay = false;
        distance = 80f;
    }
}
