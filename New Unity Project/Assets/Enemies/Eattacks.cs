using UnityEngine;
using System.Collections;


public class Eattacks : MonoBehaviour
{

    RaycastHit2D hitting;
    Collider2D detect;
    public Vector2 AIposition;
    public LayerMask whatIsPlayer;
    float Dmg;
    public float side = 1;
    public float knockbackSide;
    public bool isOnCooldown = false;
    public bool gothit = false;

    public bool swinging;
    public float swing_timeleft;
    public float cooldown = 1.5f;
    Timer timer;
    Timer swingtimer;
    bool oncd = false;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        swingtimer = gameObject.AddComponent<Timer>();
        timer.SetTimer(1, 1, new System.Action(() => { oncd = false; }));
        swingtimer.SetTimer(0.4f, 1, new System.Action(() => { swinging = false; }));
    }

    void Update()
    {
        //if (cooldown > 0) cooldown -= Time.deltaTime;
        //if (swinging && swing_timeleft > 0) swing_timeleft -= Time.deltaTime;
        //if (swinging && swing_timeleft <= 0)
        //{
        //    swinging = false;
        //    swing_timeleft = 0.4f;
        //}

        AIposition.x = transform.position.x;
        AIposition.y = transform.position.y;
        detect = Physics2D.OverlapCircle(AIposition, 1.0f, whatIsPlayer);
        //       if (detect && !swinging) swinging = true;
        if (detect && !oncd)
        {
            oncd = true;
            timer.StartTimer();

            swinging = true;
            swingtimer.StartTimer();

            Hit();
            //swinging = false;
            //swing_timeleft = 0.4f;
        }


    }

    //void OnDrawGizmos()
    //{
    //    float startx = gameObject.transform.position.x;
    //    float starty = gameObject.transform.position.y;
    //    float endx = 0;
    //    bool fr = true;
    //    if (gameObject.name == "Slime" || gameObject.name == "Slime(Clone)") fr = gameObject.GetComponent<Slime_AI>().facingRight;
    //    else if (gameObject.name == "Caster" || gameObject.name == "Caster(Clone") fr = gameObject.GetComponent<Caster_AI>().facingRight;
    //    else fr = gameObject.GetComponent<First_AI>().facingRight;

    //    if (fr) endx = 1.5f;
    //    else endx = -1.5f;

    //    Gizmos.DrawLine(new Vector2(startx, starty), new Vector2(startx + endx, starty));
    //    Gizmos.DrawLine(new Vector2(startx, starty + 0.3f), new Vector2(startx + endx, starty + 0.3f));
    //}

    public void Hit()
    {

        Estats statScript = GetComponent<Estats>();
        Dmg = statScript.aDamage;
        RaycastHit2D line1;
        RaycastHit2D line2;

        float startx = gameObject.transform.position.x;
        float starty = gameObject.transform.position.y;
        float endx = 0;
        bool fr = true;
        if (gameObject.name == "Slime" || gameObject.name == "Slime(Clone)") fr = gameObject.GetComponent<Slime_AI>().facingRight;
        else if (gameObject.name == "Caster" || gameObject.name == "Caster(Clone)") fr = gameObject.GetComponent<Caster_AI>().facingRight;
        else fr = gameObject.GetComponent<First_AI>().facingRight;

        if (fr) endx = 1.5f;
        else endx = -1.5f;

        line1 = Physics2D.Linecast(new Vector2(startx, starty), new Vector2(endx, starty), whatIsPlayer);
        line2 = Physics2D.Linecast(new Vector2(startx, starty + 0.3f), new Vector2(endx, starty + 0.3f), whatIsPlayer);

        if (line1 && line1.collider.gameObject.tag != "Player") return;
        if (line2 && line2.collider.gameObject.tag != "Player") return;

        if (line1 && line2)
        {
            line1.collider.gameObject.GetComponent<Pstats>().getHit(Dmg);
        }
        else if (line1)
        {
            line1.collider.gameObject.GetComponent<Pstats>().getHit(Dmg);
        }
        else if (line2)
        {
            line2.collider.gameObject.GetComponent<Pstats>().getHit(Dmg);
        }

        if (line1 || line2)
        {

        }

    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().meleeHit, GameObject.Find("Player").gameObject.transform.position);
        Estats statScript = GetComponent<Estats>();
        Dmg = statScript.aDamage;

        bool fr = false;
        if (gameObject.name == "Slime" || gameObject.name == "Slime(Clone)") fr = gameObject.GetComponent<Slime_AI>().facingRight;
        else if (gameObject.name == "Caster" || gameObject.name == "Caster(Clone") fr = gameObject.GetComponent<Caster_AI>().facingRight;
        else fr = gameObject.GetComponent<First_AI>().facingRight;

        if (fr)
        {
            hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 0.6f, transform.position.y), whatIsPlayer);
        }
        else
        {
            hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 0.6f, transform.position.y), whatIsPlayer);
        }

        if (hitting)
        {
            hitting.collider.GetComponent<Pstats>().getHit(Dmg);
            //            hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10.0f, 5.0f));
        }
    }
}
