using UnityEngine;
using System.Collections;

public class MagicPeashooter : BaseSpell {
	GameObject go;

	public MagicPeashooter(GameObject g)
	{
		Left = true;
		SpellName = "Magic Peashooter";
		go = g;
	}

	public override void Stats ()
	{
		Cooldown = 0;
		Cost = 1;
		Damage = go.GetComponent<Pstats> ().sDamage * 0.4f;
	}

	public override void Effect ()
	{
		GameObject pea = (GameObject)Object.Instantiate (Resources.Load ("Spells/Pea"));
		pea.transform.position = go.transform.position;
		if (Left) {
			pea.transform.position = new Vector2(go.transform.position.x - 1, go.transform.position.y);
			pea.rigidbody2D.velocity = new Vector2(-18, 0);
				} else {
			pea.transform.position = new Vector2(go.transform.position.x + 1, go.transform.position.y);
			pea.rigidbody2D.velocity = new Vector2(18, 0);
				}	
		go.GetComponent<Pstats> ().charges -= 1;
	}
}

public class Chargebolt : BaseSpell {
	GameObject go;
	public Chargebolt(GameObject g)
	{
		SpellName = "Chargebolt";
		go = g;
	}
	
	public override void Stats ()
	{
		Cooldown = 6;
		Cost = go.GetComponent<Pstats>().charges;
		Damage = go.GetComponent<Pstats> ().charges + go.GetComponent<Pstats> ().sDamage * 0.5f;
	}

	public override void Effect ()
	{
		//NULL
	}
}

public class GodBlessYou : BaseSpell {
	GameObject go;
	public GodBlessYou(GameObject g)
	{
		SpellName = "God Bless You";
		go = g;
	}

	public override void Effect ()
	{
		//TODO: Convert enemy
	}
	public override void Stats ()
	{
		Cooldown = 10;
		Cost = 0;
		Damage = 0;
	}
}

public class HolyWater : BaseSpell {
	GameObject go;
	public HolyWater(GameObject g)
	{
		SpellName = "Holy Water";
		go = g;
	}
	
	public override void Effect ()
	{
		//TODO: Creats an AOE that deals 20% of sDamage each second for 3s
	}
	public override void Stats ()
	{
		Cooldown = 3;
		Cost = 4;
		Damage = go.GetComponent<Pstats> ().sDamage * 0.2f;
	}
}

public class YaosShield : BaseSpell {
	GameObject go;
	public YaosShield(GameObject g)
	{
		SpellName = "Yao's Shield";
		go = g;
	}
	
	public override void Effect ()
	{
		//TODO: Summons a mighty shield which moves forward and pushes enemies hit back a short distance. Lasts 3s. The shield can also be jumped on and has standard collision.
	}
	public override void Stats ()
	{
		Cooldown = 5;
		Cost = 4;
		Damage = go.GetComponent<Pstats> ().sDamage * 0.2f;
	}
}

