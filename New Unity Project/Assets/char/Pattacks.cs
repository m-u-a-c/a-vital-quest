﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class Pattacks : MonoBehaviour
{

    public RaycastHit2D hitting;
    public Transform enemycheck;
    Vector2 checkArea;
    public LayerMask whatIsEnemy;
    public float timeleft;
    public float swing_timeleft = 1.5f, cast_timeleft = 1;
    public bool swinging, casting;
    float Dmg;
    public float side = 1;
    public float knockbackSide;
    public bool isOnCooldown = false;
    public bool invincible = false;

    public AudioClip swingSound, hitSound, chargeboltHit, chargeboltUse, peashooterUse, peashooterHit, pickUpItem, meleeHit, chestOpen, enemySplat, landing, yaosShieldUse, yaosShieldHit, holyWater;

    //UI
    public Image spellimage;
    void Start()
    {
        GetComponent<Pinventory>().AddItem(new AsgardSouvenir(gameObject));
    }

    void Update()
    {


        if (swinging) swing_timeleft -= Time.deltaTime;
        if (casting) cast_timeleft -= Time.deltaTime;
        if (swinging && swing_timeleft <= 0) swinging = false;
        if (casting && cast_timeleft <= 0) casting = false;

        timeleft -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !swinging)
        {
            swinging = true;
            swing_timeleft = 0.25f;

            switch (gameObject.GetComponent<Movement>().facingRight)
            {
                case true:
                    hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 1, transform.position.y), LayerMask.GetMask("Enemies"));
                    break;
                case false:
                    hitting = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 1, transform.position.y), LayerMask.GetMask("Enemies"));
                    break;
            }
        }

        // Call all item Effect() to ensure effect execution
        foreach (BaseItem bi in GetComponent<Pinventory>().items) bi.Effect();

        if (hitting && hitting.collider.gameObject.tag == "Enemy" && !gameObject.GetComponent<Pinventory>().CheckForItem(new TabletOfShadows(gameObject)))
        {
            var bb = gameObject.GetComponent<Pstats>().aDamage;
            var aa = hitting.collider.gameObject.name;
            var rnd = new System.Random();
            int result = rnd.Next(101);
            if (GetComponent<Pstats>().critchance >= result)
            {
                hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage * GetComponent<Pstats>().critmultiplier);
                hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide, 0.04f));
                Debug.Log("Crit", null);
            }
            else
            {
                hitting.collider.gameObject.GetComponent<Estats>().getHit(gameObject.GetComponent<Pstats>().aDamage);
                hitting.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackSide, 0.02f));
                Debug.Log("Not Crit", null);
            }

            AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position, 0.7f);
            hitting = new RaycastHit2D();
        }
		else if (hitting && hitting.collider.gameObject.tag == "Spawner" && !hitting.collider.gameObject.GetComponent<Pinventory>().CheckForItem(new TabletOfShadows(gameObject)))
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

        #region Casting
        int selected_spell = gameObject.GetComponent<Pinventory>().selected_spell;
        if (gameObject.GetComponent<Pstats>().charges > 0 && GetComponent<Pinventory>().spell_cooldowns_left[selected_spell] <= 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<Pinventory>().spell_cooldowns_left[selected_spell] = GetComponent<Pinventory>().spell_cooldowns[selected_spell];
            ;

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