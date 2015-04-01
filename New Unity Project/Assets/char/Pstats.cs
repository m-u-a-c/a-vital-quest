using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Pstats : MonoBehaviour
{
    public float aDamage
    {
        get
        {
            return aDamage_base + aDamage_e;
        }
    }
    public float aDamage_base;
    public float aDamage_e;

    public float sDamage
    {
        get
        {
            return sDamage_base + sDamage_e;
        }
    }
    public float sDamage_e;

    public float sDamage_base;
    public float aSpeed = 2;
    public float health = 100;
    public float maxhealth = 100;
    public float knockbackmultiplier = 1;
    public bool takedamage = true;
    //TODO: 
    public float healthreg = 0.2f;
    public float charges = 5;
    //TODO: 
    public float chargereg = 0.2f;
    public bool regcharges = true;
    public float maxcharges = 5;

    //TODO: 
    //In percentage:
    public float critchance
    {
        get
        {
            return critchance_e + critchance_base;
        }
    }
    public float critchance_base;
    public float critchance_e;
    public float critmultiplier = 2;
    //TODO: 
    public float movement = 1;
    public bool invincible = false;

    //UI
    public Slider healthbar;
    public Slider chargeslider;

    public float timeleft = 1;
    public float invincibilitytimer = 4.0f;

    Timer hptimer, chtimer;

    void Start()
    {
        hptimer = gameObject.AddComponent<Timer>();
        chtimer = gameObject.AddComponent<Timer>();
        hptimer.SetTimer(0.2f, 0, new System.Action(HpReg));
        chtimer.SetTimer(0.2f, 0, new System.Action(ChReg));
    }


    void HpReg()
    {
        if (health < maxhealth)
            health += healthreg;
    }

    void ChReg()
    {
        if (charges < maxcharges && regcharges)
            charges += chargereg;
    }

    void Update()
    {
        if (charges >= maxcharges)
            charges = 5;
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOver");
        }
        chargeslider.value = charges;
        healthbar.value = health;

    }


    public void getHit(float damageTaken, GameObject sender = null)
    {


        if (!takedamage)
        {
            //	AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().barrierBlock, gameObject.transform.position, 1f);
        }

        if (!invincible && takedamage)
        {
            if (sender != null && sender.name.Contains("Enemy"))
                AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().meleeHit, GameObject.Find("Player").gameObject.transform.position);
            //if (sender.name.Contains("Slime"));
            //if (sender.name.Contains("Caster"));

            var col = gameObject.GetComponent<SpriteRenderer>().color;
            col = new Color(col.r, 0, 0);
            var timer = gameObject.AddComponent<Timer>();
            timer.SetTimer(0.1f, 20, () =>
            {
                col = new Color(col.r, col.g + 0.05f, col.b + 0.05f);
                gameObject.GetComponent<SpriteRenderer>().color = col;
            });

            health -= damageTaken;
            healthbar.value = health;
            StartCoroutine("Invincibility");
        }

    }

    IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilitytimer);
        invincible = false;
    }



}
