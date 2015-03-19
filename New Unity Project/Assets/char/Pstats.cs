using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pstats : MonoBehaviour
{
    public float aDamage = 20;
    public float aDamage_original = 10;
    public float sDamage = 50;
    public float defense = 2;
    public float aSpeed = 100;
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
    public float critchance = 5f;
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


    public void getHit(float damageTaken)
    {
		if (!takedamage)
		{
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().barrierBlock, gameObject.transform.position, 1f);
		}

        if (!invincible && takedamage)
        {
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
