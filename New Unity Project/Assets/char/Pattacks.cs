using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml;

public class Pattacks : MonoBehaviour
{

    public RaycastHit2D hitting;
    public Transform enemycheck;
    Vector2 checkArea;
    public LayerMask whatIsEnemy;
    public float timeleft;
    public float swing_timeleft = 1.5f, cast_timeleft = 1;
    public bool swinging, casting;
    public float side = 1;
    public float knockbackSide;
    public bool isOnCooldown;
    public bool invincible;
    public int hits;
        
    public AudioClip swingSound, hitSound, chargeboltHit, chargeboltUse, peashooterUse, peashooterHit, pickUpItem, meleeHit, casterHit, slimeHit, chestOpen, enemySplat, landing, yaosShieldUse, yaosShieldHit, holyWater, staticCoreActivation, staticCoreHit, barrierActivation, barrierBlock, lazerUse;


    //UI
    public Image spellimage;
    void Start()
    {
        // GetComponent<Pinventory>().AddItem(new AsgardSouvenir(gameObject));
    }

    void Update()
    {

        if (swinging) swing_timeleft -= Time.deltaTime;
        if (casting) cast_timeleft -= Time.deltaTime;
        if (swinging && swing_timeleft <= 0)
        {
            swinging = false;
            gameObject.GetComponent<Animator>().speed = 1;
        }
        if (casting && cast_timeleft <= 0) casting = false;
        timeleft -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !swinging)
        {
            AudioSource.PlayClipAtPoint(swingSound, gameObject.transform.position, 0.7f);
            swinging = true;
            swing_timeleft = 0.25f / GetComponent<Pstats>().aSpeed;
            gameObject.GetComponent<Animator>().speed *= GetComponent<Pstats>().aSpeed;
            switch (gameObject.GetComponent<Movement>().facingRight)
            {
                case true:
                    hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 1.5f, transform.position.y), whatIsEnemy);
                    break;
                case false:
                    hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 1.5f, transform.position.y), whatIsEnemy);
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) &&
                 gameObject.GetComponent<Pinventory>().CheckForItem((new TabletOfShadows(gameObject))))
        {
            var bounds = gameObject.renderer.bounds;
            var colls = Physics2D.OverlapAreaAll(
                new Vector2(bounds.max.y, bounds.center.x),
                new Vector2(bounds.min.y, gameObject.GetComponent<Movement>().facingRight ? bounds.center.x + 2 : bounds.center.x - 2),
                LayerMask.GetMask("Enemies"));
            if (colls.Length > 0)
            {
                var gos = new List<int>();
                foreach (var coll in colls.Where(coll => !gos.Contains(coll.gameObject.GetInstanceID())))
                {
                    gos.Add(coll.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage));
                }
            }
        }

        // Call all item Effect() to ensure effect execution
        foreach (BaseItem bi in GetComponent<Pinventory>().items) bi.Effect();

        if (hitting && hitting.collider.gameObject.tag == "Enemy" && !gameObject.GetComponent<Pinventory>().CheckForItem(new TabletOfShadows(gameObject)))
        {
            var pstats = gameObject.GetComponent<Pstats>();
            var rnd = new System.Random();
            var result = rnd.Next(101);
            if (GetComponent<Pstats>().critchance >= result)
            {
                hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage * GetComponent<Pstats>().critmultiplier, true, true);
                hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide * pstats.knockbackpower, 0.04f * pstats.knockbackpower * 2));
            }
            else
            {
                hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage);
                hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide * pstats.knockbackpower, 0.02f * pstats.knockbackpower * 2));
            }

            AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position, 0.7f);
            foreach (BaseItem item in gameObject.GetComponent<Pinventory>().items)
                if (item.animation != 4)
                {
                    AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().staticCoreHit, GameObject.Find("Player").gameObject.transform.position);
                    break;
                }
            hitting = new RaycastHit2D();
        }
        else if (hitting && hitting.collider.gameObject.tag == "Spawner" && !gameObject.GetComponent<Pinventory>().CheckForItem(new TabletOfShadows(gameObject)))
        {
            float bb = gameObject.GetComponent<Pstats>().aDamage;
            var aa = hitting.collider.gameObject.name;
            hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage);
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


        //		if (Input.GetKey (KeyCode.Mouse0) && hittin && !isOnCooldown)
        //		{
        //
        //			StartCoroutine(Cooldown());
        //			if(hittin)
        //			{
        //				if (hittin.tag == "Enemy") );
        //			}
        //		}

        #region Casting
        int selected_spell = gameObject.GetComponent<Pinventory>().selected_spell;
        if (gameObject.GetComponent<Pinventory>().spells != null && gameObject.GetComponent<Pinventory>().spells.Count > 0  )
            if (gameObject.GetComponent<Pstats>().charges > 0 && gameObject.GetComponent<Pstats>().charges >= GetComponent<Pinventory>().spells[selected_spell].Cost && !GetComponent<Pinventory>().spell_cds[selected_spell].running && Input.GetKeyDown(KeyCode.Mouse1))
            {
                #region Merlin's Band


                if (gameObject.GetComponent<Pinventory>().CheckForItem(new MerlinsBandofFate(gameObject)))
                {
                    gameObject.GetComponent<Pstats>().movement += 0.5f;
                    var timer = gameObject.AddComponent<Timer>();
                    timer.SetTimer(1, 1, () =>
                    {
                        gameObject.GetComponent<Pstats>().movement -= 0.5f;
                        Destroy(timer);
                    });
                }
                #endregion

                var spell = gameObject.GetComponent<Pinventory>().spells[selected_spell];
                if (gameObject.GetComponent<Movement>().facingRight)
                {
                    gameObject.GetComponent<Pinventory>().spells[selected_spell].Left = false;
                }
                else
                    gameObject.GetComponent<Pinventory>().spells[selected_spell].Left = true;

                if (gameObject.GetComponent<Pinventory>().spells[selected_spell].Cost <= gameObject.GetComponent<Pstats>().charges)
                    gameObject.GetComponent<Pinventory>().spells[selected_spell].Effect();

                timeleft = gameObject.GetComponent<Pinventory>().spells[selected_spell].Cooldown;
                casting = true;
                cast_timeleft = 0.12f;
                GetComponent<Pinventory>().spell_cds[selected_spell].StartTimer();
            }
        #endregion

    }

    void OnDrawGizmos()
    {
        //case true:
        //           hitting = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 5.0f, transform.position.y));
        //           break;
        //       case false:
        //           hitting = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 5.0f, transform.position.y));
        //           break;

        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 5, transform.position.y));
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 5, transform.position.y));
    }


    public IEnumerator Cooldown()
    {
        isOnCooldown = true;
        Pstats statScript = GetComponent<Pstats>();
        yield return new WaitForSeconds(statScript.aSpeed);
        isOnCooldown = false;
    }
}