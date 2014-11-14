using UnityEngine;
using System.Collections;

public class Peashooter : BaseSpell {
	GameObject go;
	public Peashooter(GameObject g)
	{
		SpellName = "Peashooter";
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
		//NULL
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


