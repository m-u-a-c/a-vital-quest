using UnityEngine;
using System.Collections;

public class MagicPeashooter : BaseSpell
{
    public GameObject go {get; set;}

    public MagicPeashooter(GameObject g)
    {
        Left = true;
        SpellName = "Magic Peashooter";
        SpellDescription = "A magic peashooter that does low damage, but has no cooldown";
        go = g;
        Cooldown = 0;
        Cost = 1;
        Damage = go.GetComponent<Pstats>().sDamage * 0.4f;
		animation = 6;
    }

    public override void Effect()
    {
        var pea = (GameObject)Object.Instantiate(Resources.Load("Spells/Pea"));
        pea.transform.position = go.transform.position;
        if (Left)
        {
            
            pea.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y);
            pea.rigidbody2D.velocity = new Vector2(-35, 0);
        }
        else
        {
            pea.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y);
            pea.rigidbody2D.velocity = new Vector2(35, 0);
        }
        go.GetComponent<Pstats>().charges -= Cost;
    }

    public override void UpdateStats()
    {

    }
}

public class Chargebolt : BaseSpell
{
    public GameObject go {get; set;}

    public Chargebolt(GameObject g)
    {
        SpellName = "Chargebolt";
        go = g;

        Cooldown = 3;
        Cost = 0;
        Damage = go.GetComponent<Pstats>().charges + go.GetComponent<Pstats>().sDamage * 0.5f;
		animation = 5;
    }

    public override void Effect()
    {
        GameObject bolt = (GameObject)Object.Instantiate(Resources.Load("Spells/Chargebolt"));
        bolt.transform.position = go.transform.position;
        if (Left)
        {
            bolt.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y);
            bolt.rigidbody2D.velocity = new Vector2(-22, 0);
        }
        else
        {
            bolt.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y);
            bolt.rigidbody2D.velocity = new Vector2(22, 0);
        }
        go.GetComponent<Pstats>().charges = 0;

    }

    public override void UpdateStats()
    {
        Cost = go.GetComponent<Pstats>().charges;
        Damage = go.GetComponent<Pstats>().charges + go.GetComponent<Pstats>().sDamage * 0.5f;
    }
}

public class GodBlessYou : BaseSpell
{
    public GameObject go {get; set;}
    public GodBlessYou(GameObject g)
    {
        SpellName = "God Bless You";
        go = g;

        Cooldown = 10;
        Cost = 0;
        Damage = 0;
    }

    public override void Effect()
    {
        //TODO: Convert enemy
    }

    public override void UpdateStats()
    {

    }
}

public class HolyWater : BaseSpell
{
    public GameObject go {get; set;}
    public HolyWater(GameObject g)
    {
        SpellName = "Holy Water";
        go = g;

        Cooldown = 3;
        Cost = 4;
        Damage = go.GetComponent<Pstats>().sDamage * 0.2f;
    }

    public override void Effect()
    {
        //TODO: Creats an AOE that deals 20% of sDamage each second for 3s
        var g = (GameObject)Object.Instantiate(Resources.Load("Spells/HolyWater"));

        if (go.GetComponent<Movement>().facingRight)
        {
            g.transform.position = new Vector2(go.transform.position.x + 0.35f, go.transform.position.y);
            g.rigidbody2D.AddForce(new Vector2(20, 50));
        }
        else
        {
            g.transform.position = new Vector2(go.transform.position.x - 0.35f, go.transform.position.y);
            g.rigidbody2D.AddForce(new Vector2(-20, 50));
        }
        if (go.GetComponent<Movement>().facingRight) g.rigidbody2D.AddForceAtPosition(Vector2.right * 50, new Vector2(g.transform.position.x, g.transform.position.y + 0.1f));
        else g.rigidbody2D.AddForceAtPosition(Vector2.right * -50, new Vector2(g.transform.position.x, g.transform.position.y + 0.1f));
    }

    public override void UpdateStats()
    {

    }
}

public class YaosShield : BaseSpell
{
    public GameObject go {get; set;}
    public YaosShield(GameObject g)
    {
        SpellName = "Yao's Shield";
        go = g;

        Cooldown = 5;
        Cost = 4;
        Damage = go.GetComponent<Pstats>().sDamage * 0.2f;
		animation = 5;
    }

    public override void Effect()
    {
        GameObject shield = (GameObject)Object.Instantiate(Resources.Load("Spells/Shield"));
        shield.transform.position = go.transform.position;
        if (Left)
        {
            shield.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y + 0.3f);
            Vector3 theScale = shield.transform.localScale;
            theScale.x *= -1;
            shield.transform.localScale = theScale;
            shield.rigidbody2D.velocity = new Vector2(-7, 0);
        }
        else
        {
            shield.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y + 0.3f);
            shield.rigidbody2D.velocity = new Vector2(7, 0);
        }
        go.GetComponent<Pstats>().charges -= Cost;
    }

    public override void UpdateStats()
    {

    }
}

public class VengefulCharge : BaseSpell
{
    public GameObject go {get; set;}
    public VengefulCharge(GameObject g)
    {
        SpellName = "Vengeful Charge";
        go = g;

        
    }

    public override void Effect()
    {
    
    }

    public override void UpdateStats()
    {

    }
}

public class Barrier : BaseSpell
{
    public GameObject go {get; set;}
    float usedcharges;
    
    public Barrier(GameObject g)
    {
        SpellName = "Barrier";
        go = g;
        Cost = 1;
        Cooldown = 8;
        SpellDescription = "Summons a barrier of light, making you invulnerable for a short period of time";

    }

    public override void Effect()
    {
        usedcharges = go.GetComponent<Pstats>().charges;
        var barrier = (GameObject)Object.Instantiate(Resources.Load("Spells/Barrier"));
        barrier.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, -3);

        if (usedcharges < 3) barrier.GetComponent<BarrierBehaviour>().ticks = 20;
        else if (usedcharges < 5) barrier.GetComponent<BarrierBehaviour>().ticks = 25;
        else if (usedcharges <= 5) barrier.GetComponent<BarrierBehaviour>().ticks = 30;

        go.GetComponent<Pstats>().charges = 0;
    }

    public override void UpdateStats()
    {

    }
}

public class PhotonBeam : BaseSpell
{
	public GameObject go {get; set;}
	public PhotonBeam(GameObject g)
	{
		SpellName = "Photon Beam";
		go = g;
		Cost = 5;
		Cooldown = 8;
        SpellDescription = "Summons a beam of light that passes through enemies and terrain, dealing a signifcant amount of spell damage";
	}

	public override void UpdateStats()
	{

	}

	public override void Effect()
	{
		var beam = (GameObject)Object.Instantiate (Resources.Load ("Spells/Laser"));
		var size = beam.GetComponent<SpriteRenderer> ().bounds.size;
	    if (go.GetComponent<Movement>().facingRight) beam.GetComponent<LaserScript>().Right = true;
		//beam.transform.position = new Vector3 (beam.transform.position.x + beam.renderer.bounds.center.x / 2, beam.transform.position.y, -2);
		if (Left)
            
		{
			beam.transform.position = new Vector3(go.transform.position.x - size.x / 1.8f + 0.8f, go.transform.position.y + 0.3f, -2);
			var theScale = beam.transform.localScale;
			theScale.x *= -1;
			beam.transform.localScale = theScale;
		}
		else
		{
			beam.transform.position = new Vector3(go.transform.position.x + size.x / 1.8f - 0.8f, go.transform.position.y + 0.3f, -2);
		}
		go.gameObject.GetComponent<Pstats> ().charges -= Cost;
	}

}

public class Bloodbolt : BaseSpell
{
    public GameObject go {get; set;}
    float usedcharges;
    
    public Bloodbolt(GameObject g)
    {
        SpellName = "Bloodbolt";
        go = g;
        Damage = 10;
    }

    public override void Effect()
    {
        GameObject bolt = (GameObject)Object.Instantiate(Resources.Load("Spells/Bloodbolt"));
        bolt.transform.position = go.transform.position;
        if (!go.GetComponent<Caster_AI>().facingRight)
        {
            bolt.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y);
           // bolt.rigidbody2D.velocity = new Vector2(-15, 0);
            bolt.rigidbody2D.velocity = Vector2.MoveTowards(bolt.transform.position, -GameObject.Find("Player").transform.position, 1000);
            bolt.rigidbody2D.velocity = bolt.rigidbody2D.velocity * 0.5f;
        }
        else
        {
            bolt.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y);
            //bolt.rigidbody2D.velocity = new Vector2(15, 0);
            bolt.rigidbody2D.velocity = Vector2.MoveTowards(bolt.transform.position, GameObject.Find("Player").transform.position, 1000);
            bolt.rigidbody2D.velocity = bolt.rigidbody2D.velocity * 0.5f;
        }

        Vector3 vec = bolt.transform.localScale * -1;
        if (!go.GetComponent<Caster_AI>().facingRight)
            bolt.GetComponent<SpriteRenderer>().transform.localScale = vec;
    }

    public override void UpdateStats()
    {
        throw new System.NotImplementedException();
    }
}