using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour
{
    //runnin & jumpin
    public float maxSpeed = 1;
    public float jumpForce = 50f;
    public float jumptime = 0.0f;
    bool onCooldown = false;

    public bool lastframegrounded;

    public Vector2 playerposition;
    public Collider2D grounded;
    public Transform groundcheck;
    float groundRadius = 0.24f;
    public LayerMask whatIsGround;
    float last_yvel = 0;
    float last_xvel = 0;
    public float platformspeed = 0;

    //flipping
    public bool facingRight = true;
    bool moving = false;
    public float speed;

    void Update()
    {
		if (Time.timeScale > 0 && Input.GetKeyDown (KeyCode.C))
		{
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().casterHit, gameObject.transform.position);
		}
		if (Time.timeScale > 0 && Input.GetKeyDown (KeyCode.V))
		{
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().slimeHit, gameObject.transform.position, 0.5f);
		}

        if (grounded && Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) >= 1 && grounded && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().pitch = 0.8f;
        }
        if ((!grounded) || Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < 1)
            gameObject.GetComponent<AudioSource>().Pause();

        if (gameObject.GetComponent<Pattacks>().swinging)
        {
            bool specwep = false;
            if (gameObject.GetComponent<Pinventory>().items.Count > 0)
                foreach (BaseItem item in gameObject.GetComponent<Pinventory>().items)
                {
                    if (item.animation != 4)
                    {
                        gameObject.GetComponent<Animator>().SetInteger("State", gameObject.GetComponent<Pinventory>().items[gameObject.GetComponent<Pinventory>().items.IndexOf(item)].animation);
                        AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().staticCoreHit, GameObject.Find("Player").gameObject.transform.position);
                        specwep = true;
                        break;
                    }
                }
            if (!specwep) gameObject.GetComponent<Animator>().SetInteger("State", 4);
        }

        else if (gameObject.GetComponent<Pattacks>().casting)
            gameObject.GetComponent<Animator>().SetInteger("State", GetComponent<Pinventory>().spells[GetComponent<Pinventory>().selected_spell].animation);

        else if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) <= 2 && GetComponent<Rigidbody2D>().velocity.y <= 2 && grounded && !gameObject.GetComponent<Pattacks>().casting)
        {
            gameObject.GetComponent<Animator>().SetInteger("State", 3);
        }

        else
        {
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && !grounded)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 0);

            }
            else if (GetComponent<Rigidbody2D>().velocity.y < 0 && !grounded) gameObject.GetComponent<Animator>().SetInteger("State", 2);
            else if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0 && grounded)
            {
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
        }


        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.X)) GetComponent<Pstats>().health -= 5;


        speed = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        moving = !(Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 3);

        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        var move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed * GetComponent<Pstats>().movement * 0.8f, GetComponent<Rigidbody2D>().velocity.y);

        if (grounded && grounded.gameObject.name == "MovingPlatform")
            transform.parent = grounded.gameObject.transform;
        if (grounded && grounded.gameObject.name == "VMovingPlatform")
            transform.parent = grounded.gameObject.transform;
           // rigidbody2D.velocity = new Vector2(grounded.rigidbody2D.velocity.x + move * maxSpeed * GetComponent<Pstats>().movement, grounded.rigidbody2D.velocity.y);

       if (grounded && grounded.gameObject.tag == "Spike") 
           gameObject.GetComponent<Pstats>().getHit(gameObject.GetComponent<Pinventory>().CheckForItem(new SturdySocks(gameObject)) ? 20 : 40);
             

        playerposition.x = GetComponent<Rigidbody2D>().transform.position.x;
        playerposition.y = GetComponent<Rigidbody2D>().transform.position.y;

        //Pattacks attacks = GetComponent<Pattacks>();
        //gameObject.GetComponent<Pinventory> ().spell = new Chargebolt (gameObject);
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        //Always last:
        last_yvel = (gameObject.GetComponent<Rigidbody2D>().velocity.y);
        last_xvel = Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x);

    }
    void Start()
    {
        //		gameObject.GetComponent<Pinventory> ().spell = new YaosShield(gameObject);
        //gameObject.GetComponent<Pinventory>().AddSpell(new MagicPeashooter(gameObject));
        //gameObject.GetComponent<Pinventory>().AddSpell(new Barrier(gameObject));
        //gameObject.GetComponent<Pinventory>().AddSpell(new PhotonBeam(gameObject));
        

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
