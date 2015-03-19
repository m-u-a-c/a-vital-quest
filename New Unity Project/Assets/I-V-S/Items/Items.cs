using UnityEngine;
using System.Collections;

public class HolyGrail : BaseItem
{
    GameObject go;
    public HolyGrail(GameObject g)
    {
        go = g;
        ItemName = "Holy Grail";
    }
    public override void Effect()
    {

    }
    public override void Stats()
    {
        go.GetComponent<Pstats>().healthreg += 5;
        go.GetComponent<Pstats>().maxhealth += 15;
    }
    public override void RevertStats()
    {
        go.GetComponent<Pstats>().healthreg -= 5;
        go.GetComponent<Pstats>().maxhealth -= 15;
    }
}

public class FriarTucksRobe : BaseItem
{
    GameObject go;

    public FriarTucksRobe(GameObject g)
    {
        go = g;
        ItemName = "Friar Tuck's Robe";
    }
    public override void Effect()
    {
    }

    public override void Stats()
    {
        go.GetComponent<Pstats>().charges += 2;
        go.GetComponent<Pstats>().chargereg *= 0.5f;
    }

    public override void RevertStats()
    {
        go.GetComponent<Pstats>().chargereg /= 0.5f;
    }

}

public class GlassIdol : BaseItem
{
    GameObject go;
    public GlassIdol(GameObject g)
    {
        go = g;
        ItemName = "Elixir of Life";
    }

    public override void Effect()
    {
        //TODO: Restores you to full HP and Charges when brought below 10 HP. Breaks on effect.
        if (go.GetComponent<Pstats>().health < 10)
        {
			go.GetComponent<Pstats>().health = go.GetComponent<Pstats>().maxcharges;
            go.GetComponent<Pstats>().charges = go.GetComponent<Pstats>().maxcharges;
            go.GetComponent<Pinventory>().RemoveItem(this);
        }

    }

    public override void Stats()
    {
        //NULL
    }
    public override void RevertStats()
    {

    }
}

public class LuckyHorseshoe : BaseItem
{
    GameObject go;
    public LuckyHorseshoe(GameObject g)
    {
        go = g;
        ItemName = "Lucky Horseshoe";
    }
    public override void Effect()
    {
    }
    public override void Stats()
    {
        go.GetComponent<Pstats>().critchance += 10;

    }
    public override void RevertStats()
    {
        go.GetComponent<Pstats>().critchance -= 10;
    }
}

public class BootsOfUrgency : BaseItem
{
    GameObject go;
    public BootsOfUrgency(GameObject g)
    {
        go = g;
        ItemName = "Boots of Urgency";
    }
    public override void Effect()
    {

    }

    public override void Stats()
    {
        //go.GetComponent<Pstats> ().aSpeed += 0.2f;
        go.GetComponent<Pstats>().movement += 0.2f;
    }
    public override void RevertStats()
    {
        go.GetComponent<Pstats>().movement -= 0.2f;
    }
}

public class SturdySocks : BaseItem
{
    GameObject go;
    public SturdySocks(GameObject g)
    {
        go = g;
        ItemName = "Sturdy Socks";
    }
    public override void Effect()
    {

    }
    public override void Stats()
    {
        go.GetComponent<Pstats>().aDamage += 3;
        go.GetComponent<Pstats>().knockbackmultiplier = 0;
    }
    public override void RevertStats()
    {
        go.GetComponent<Pstats>().aDamage -= 3;
        go.GetComponent<Pstats>().knockbackmultiplier = 1;
    }
}

public class MysticalOrb : BaseItem
{
    GameObject go;
    public MysticalOrb(GameObject g)
    {
        go = g;
        ItemName = "Mystical Orb";
    }
    public override void Effect()
    {

    }

    public override void Stats()
    {
        go.GetComponent<Pstats>().sDamage += 3;
        go.GetComponent<Pstats>().chargereg += 2;
    }
    public override void RevertStats()
    {
        go.GetComponent<Pstats>().sDamage -= 3;
        go.GetComponent<Pstats>().chargereg -= 2;
    }
}

public class VampiricCrest : BaseItem
{
    GameObject go;
    public VampiricCrest(GameObject g)
    {
        go = g;
        ItemName = "Vampiric Crest";
    }
    public override void Effect()
    {
        var hitting = go.GetComponent<Pattacks>().hitting;
        if (hitting && hitting.collider.gameObject.tag == "Enemy" && hitting.collider.gameObject.GetComponent<Estats>().health <= 15)
        {
            Debug.Log("Vampire", null);
            hitting.collider.gameObject.GetComponent<Estats>().getHit(15);
            go.GetComponent<Pstats>().health += 3;
        }
    }

    public override void Stats()
    {

    }
    public override void RevertStats()
    {

    }
}

public class StaticCore : BaseItem
{
    GameObject go;
	GameObject camera;
    bool on = false;
    float timeleft = 1.5f;
    float ori_damage;
	AudioSource AS;
    public StaticCore(GameObject g)
    {
        go = g;
        ItemName = "Static Core";
        ori_damage = go.GetComponent<Pstats>().aDamage;
        animation = 4;
		camera = GameObject.Find ("Camera");
		AS = camera.AddComponent<AudioSource> ();
		AS.clip = GameObject.Find ("Player").GetComponent<Pattacks> ().staticCoreActivation;
		
    }
    public override void Effect()
    {
        var pstats = go.GetComponent<Pstats>();
        if (Input.GetKeyDown(go.GetComponent<Pinventory>().CheckSlot(this)))
        {
            if (!on && go.GetComponent<Pstats>().charges == 5)
            {
                TurnOn();
            }
            else if (on && go.GetComponent<Pstats>().charges < 5) 
            {
                TurnOff();
            }
        }
        if (on)
        {
            timeleft -= Time.deltaTime;
        }

        if (on && timeleft <= 0)
        {
            go.GetComponent<Pstats>().charges -= 1;
            timeleft = 1.5f;
        }

        if (on && go.GetComponent<Pstats>().charges <= 0)
        {
            TurnOff();
        }
    }

    public void TurnOn()
    {
		AS.Play ();
		AS.volume = 1.2f;
        animation = 7;
        on = true;
		go.GetComponent<Pinventory>().slots[go.GetComponent<Pinventory>().items.IndexOf(this)].sprite = go.GetComponent<Pinventory>().Core_Uncharged;
        go.GetComponent<Pstats>().regcharges = false;
        go.GetComponent<Pstats>().aDamage = ori_damage + go.GetComponent<Pstats>().sDamage * 0.6f;
    }
    public void TurnOff()
    {
		AS.Pause ();
        animation = 4;
        on = false;
        go.GetComponent<Pinventory>().slots[go.GetComponent<Pinventory>().items.IndexOf(this)].sprite = go.GetComponent<Pinventory>().Core_Charged;
        go.GetComponent<Pstats>().regcharges = true;
        go.GetComponent<Pstats>().aDamage = ori_damage;
        timeleft = 1;
    }

    public override void Stats()
    {

    }
    public override void RevertStats()
    {

    }
}

public class AsgardSouvenir : BaseItem
{
    GameObject go;
    int hitcount;

    public AsgardSouvenir(GameObject g)
    {
        go = g;
        ItemName = "Asgard Souvenir";
    }
    public override void Effect()
    {
        if (Input.GetKeyDown(go.GetComponent<Pinventory>().CheckSlot(this)))
        {
            var g = (GameObject)Object.Instantiate(Resources.Load("Items/Asgard"));
            g.transform.position = go.transform.position;
            if (!go.GetComponent<Movement>().facingRight)
            {
                g.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y);
                g.rigidbody2D.velocity = new Vector2(-40, 0);
            }
            else
            {
                g.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y);
                g.rigidbody2D.velocity = new Vector2(40, 0);
            }
        }
    }

    public override void Stats()
    {

    }


    public override void RevertStats()
    {

    }
}

public class TabletOfShadows : BaseItem
{
	GameObject go;
	int hitcount;
	public float cd = 0.2f;
	public bool available = false;
	Timer timer;

	public TabletOfShadows(GameObject g)
	{
		go = g;
		ItemName = "Tablet of Shadows";
		timer = go.AddComponent<Timer> ();
		timer.SetTimer (0.2f, 1, new System.Action (ClearCD)); 
	}

	void ClearCD()
	{
		available = true;
		timer.StopTimer ();
	}


	public override void Effect()
	{
//		if (!available && !go.GetComponent<Pattacks>().hitting)
//						return;
//		Debug.Log ("HORA", null);
//
//			bool facingRight = GameObject.Find ("Player").GetComponent<Movement> ().facingRight;
//			var g = (GameObject)Object.Instantiate(Resources.Load("Spells/ShadowHitbox"));
//			if (facingRight)
//				g.transform.position = new Vector2 (go.transform.position.x + 0.75f, go.transform.position.y);
//			else
//				g.transform.position = new Vector2 (go.transform.position.x - 0.75f, go.transform.position.y);
//
//		timer.StartTimer ();


	}
	
	public override void Stats()
	{
		
	}
	
	
	public override void RevertStats()
	{
		
	}
}

public class Bandaid : BaseItem
{
	GameObject go;
	Pstats pstats;
	public Bandaid(GameObject g)
	{
		go = g;
		ItemName = "Bandaid";
		pstats = go.GetComponent<Pstats> ();
	}
	public override void Effect()
	{

	}
	
	public override void Stats()
	{
		pstats.health	 += 10;
		pstats.maxhealth += 10;
		pstats.healthreg += 2;
	}

	public override void RevertStats()
	{
		pstats.maxhealth -= 10;
		pstats.healthreg -= 2;
	}
}

public class CharmOfRestoration : BaseItem
{
	GameObject go;
	Pstats pstats;
	public CharmOfRestoration(GameObject g)
	{
		go = g;
		ItemName = "Charm of Restoration";
		pstats = go.GetComponent<Pstats> ();
	}
	public override void Effect()
	{
		
	}
	
	public override void Stats()
	{
		pstats.healthreg += 3;
		pstats.movement	 *= 0.85f;
	}
	
	public override void RevertStats()
	{
		pstats.healthreg -= 3;
		pstats.movement	 /= 0.85f;
	}
}

public class ZephyrJuice : BaseItem
{
	GameObject go;
	Pstats pstats;
	public ZephyrJuice(GameObject g)
	{
		go = g;
		ItemName = "Zephyr Juice";
		pstats = go.GetComponent<Pstats> ();
	}
	public override void Effect()
	{
		if (Input.GetKeyDown (go.GetComponent<Pinventory> ().CheckSlot (this))) {
			pstats.health += 22.5f;
			go.GetComponent<Pinventory>().RemoveItem(this);
		}

	}
	
	public override void Stats()
	{ 


	}
	
	public override void RevertStats()
	{


	}
}