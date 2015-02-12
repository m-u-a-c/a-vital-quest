using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Pattacks : MonoBehaviour
{

    public RaycastHit2D hitting;
    public Transform enemycheck;
    Vector2 checkArea;
    public LayerMask whatIsEnemy;
    public float timeleft;
    public float swing_timeleft = 1.5f;
    public bool swinging;
    float Dmg;
    public float side = 1;
    public float knockbackSide;
    public bool isOnCooldown = false;
    public bool invincible = false;

	public AudioClip swingSound, hitSound, chargeboltHit, chargeboltUse, peashooterUse, peashooterHit, pickUpItem, meleeHit, chestOpen, enemySplat, landing, yaosShieldUse, yaosShieldHit;

    //UI
    public Image spellimage;
    void Start()
    {
		
    }

    void FixedUpdate()
    {


        if (swinging) swing_timeleft -= Time.deltaTime;
        if (swinging && swing_timeleft <= 0) swinging = false;

        timeleft -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !swinging)
        {
            swinging = true;
            swing_timeleft = 0.25f;

            switch (gameObject.GetComponent<Movement>().facingRight)
            {
                case true:
                    hitting = Physics2D.Raycast(new Vector2(gameObject.renderer.bounds.center.x + 0.55f, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x + 1f, gameObject.renderer.bounds.center.y - 2f));
                    break;
                case false:
                    hitting = Physics2D.Raycast(new Vector2(gameObject.renderer.bounds.center.x - 0.55f, gameObject.renderer.bounds.center.y), new Vector2(gameObject.renderer.bounds.center.x - 1f, gameObject.renderer.bounds.center.y - 2f));
                    break;
            }
        }

        if (hitting && hitting.collider.gameObject.name.Contains("Enemy"))
        {
            float bb = gameObject.GetComponent<Pstats>().aDamage;
            var aa = hitting.collider.gameObject.name;
            hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage);
            hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide, 0.05f));
            AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position, 0.7f);
            hitting = new RaycastHit2D();
        }

        if (gameObject.GetComponent<Movement>().facingRight)
        {
            side = transform.position.x + 2;
        }
        if (!gameObject.GetComponent<Movement>().facingRight)
        {
            side = transform.position.x - 2;
        }
        if (gameObject.GetComponent<Movement>().facingRight)
        {
            knockbackSide = 0.05f;
        }
        if (!gameObject.GetComponent<Movement>().facingRight)
        {
            knockbackSide = -0.05f;
        }
        checkArea = new Vector2(side, transform.position.y + 2);
        //hittin = Physics2D.OverlapArea(transform.position, checkArea, whatIsEnemy, -Mathf.Infinity, Mathf.Infinity);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            AudioSource.PlayClipAtPoint(swingSound, gameObject.transform.position, 0.7f);

        //		if (Input.GetKey (KeyCode.Mouse0) && hittin && !isOnCooldown)
        //		{
        //
        //			StartCoroutine(Cooldown());
        //			if(hittin)
        //			{
        //				if (hittin.tag == "Enemy") );
        //			}
        //		}

        if (gameObject.GetComponent<Pstats>().charges > 0 && timeleft <= 0 && Input.GetKeyDown(KeyCode.Q))
        {
            timeleft = gameObject.GetComponent<Pinventory>().spell.Cooldown;

            var spell = gameObject.GetComponent<Pinventory>().spell;
            if (gameObject.GetComponent<Movement>().facingRight)
            {
                gameObject.GetComponent<Pinventory>().spell.Left = false;
            }
            else
                gameObject.GetComponent<Pinventory>().spell.Left = true;

            if (gameObject.GetComponent<Pinventory>().spell.Cost <= gameObject.GetComponent<Pstats>().charges)
                gameObject.GetComponent<Pinventory>().spell.Effect();
        }
    }

    public IEnumerator Cooldown()
    {
        isOnCooldown = true;
        Pstats statScript = GetComponent<Pstats>();
        yield return new WaitForSeconds(statScript.aSpeed);
        isOnCooldown = false;
    }
}
