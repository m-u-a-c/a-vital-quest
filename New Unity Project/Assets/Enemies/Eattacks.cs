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


    void Start()
    {

    }

    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        if (swinging && swing_timeleft > 0) swing_timeleft -= Time.deltaTime;
        if (swinging && swing_timeleft <= 0)
        {
            swinging = false;
            swing_timeleft = 0.4f;
        }

        AIposition.x = transform.position.x;
        AIposition.y = transform.position.y;
        detect = Physics2D.OverlapCircle(AIposition, 1.0f, whatIsPlayer);
 //       if (detect && !swinging) swinging = true;
        if (detect)
        {
            Attack();
            swinging = false;
            swing_timeleft = 0.4f;
        }


    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().meleeHit, GameObject.Find("Player").gameObject.transform.position);
        Estats statScript = GetComponent<Estats>();
        Dmg = statScript.aDamage;

        if (GetComponent<First_AI>().facingRight)
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
