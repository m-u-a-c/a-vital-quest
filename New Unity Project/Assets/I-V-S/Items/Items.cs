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
        go.GetComponent<Pstats>().chargereg -= 0.5f;
    }

    public override void RevertStats()
    {
        go.GetComponent<Pstats>().chargereg += 0.5f;
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
            go.GetComponent<Pstats>().health = 100;
            go.GetComponent<Pstats>().charges = 5;
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
    bool on = false;
    float timeleft = 1.5f;

    float ori_damage;
    public StaticCore(GameObject g)
    {
        go = g;
        ItemName = "Static Core";
        ori_damage = go.GetComponent<Pstats>().aDamage;
    }
    public override void Effect()
    {
        var pstats = go.GetComponent<Pstats>();
        if (Input.GetKeyDown(KeyCode.T))
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

        on = true;
        go.GetComponent<Pinventory>().slots[go.GetComponent<Pinventory>().items.IndexOf(this)].sprite = go.GetComponent<Pinventory>().Core_Uncharged;
        go.GetComponent<Pstats>().regcharges = false;
        go.GetComponent<Pstats>().aDamage = ori_damage + go.GetComponent<Pstats>().sDamage * 0.6f;
        Debug.Log("turned on", null);
    }
    public void TurnOff()
    {
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
        if (Input.GetKeyDown(KeyCode.Q))
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
