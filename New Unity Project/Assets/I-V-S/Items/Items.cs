using UnityEngine;
using System.Collections;

public class HolyGrail : BaseItem  {
	GameObject go;
	public HolyGrail(GameObject g)
	{
		go = g;
		ItemName = "Holy Grail";
	}
	public override void Effect ()
	{

	}
	public override void Stats ()
	{
		go.GetComponent<Pstats> ().healthreg += 5;
		go.GetComponent<Pstats> ().maxhealth += 15;
	}
	public override void RevertStats ()
	{
		go.GetComponent<Pstats> ().healthreg -= 5;
		go.GetComponent<Pstats> ().maxhealth -= 15;
	}
}

public class FriarTucksRobe : BaseItem {
	GameObject go;
	
	public FriarTucksRobe(GameObject g)
	{
		go = g;
		ItemName = "Friar Tuck's Robe";
	}
	public override void Effect ()
	{
	}

	public override void Stats ()
	{
		go.GetComponent<Pstats> ().charges += 2;
		go.GetComponent<Pstats> ().chargereg -= 0.5f;
	}

	public override void RevertStats ()
	{
		go.GetComponent<Pstats> ().chargereg += 0.5f;
	}

}

public class GlassIdol : BaseItem {
	GameObject go;
	public GlassIdol(GameObject g)
	{
		go = g;
		ItemName = "Glass Idol";
	}

	public override void Effect ()
	{
		//TODO: Restores you to full HP and Charges when brought below 10 HP. Breaks on effect.
        if (go.GetComponent<Pstats>().health < 10)
        {
            go.GetComponent<Pstats>().health = 100;
            go.GetComponent<Pstats>().charges = 5;
            go.GetComponent<Pinventory>().RemoveItem(this);
        }
        
	}

	public override void Stats ()
	{
		//NULL
	}
	public override void RevertStats ()
	{

	}
}

public class LuckyHorseshoe : BaseItem {
	GameObject go;
	public LuckyHorseshoe(GameObject g)
	{
		go = g;
		ItemName = "Lucky Horseshoe";
	}
	public override void Effect()
	{
	}
	public override void Stats ()
	{
		go.GetComponent<Pstats> ().critchance += 10;
		
	}
	public override void RevertStats ()
	{
		go.GetComponent<Pstats> ().critchance -= 10;
	}
}

public class BootsOfUrgency : BaseItem {
	GameObject go;
	public BootsOfUrgency(GameObject g)
	{
		go = g;
		ItemName = "Boots of Urgency";
	}
	public override void Effect()
	{

	}

	public override void Stats ()
	{
		//go.GetComponent<Pstats> ().aSpeed += 0.2f;
		go.GetComponent<Pstats> ().movement += 0.2f;
	}
	public override void RevertStats ()
	{
		
	}
}

public class SturdySocks : BaseItem {
	GameObject go;
	public SturdySocks(GameObject g)
	{
		go = g;
		ItemName = "Sturdy Socks";
	}
	public override void Effect()
	{

	}
	public override void Stats ()
	{
		go.GetComponent<Pstats> ().aDamage += 3;
		go.GetComponent<Pstats> ().knockbackmultiplier = 0;
	}
	public override void RevertStats ()
	{
		go.GetComponent<Pstats> ().aDamage -= 3;
		go.GetComponent<Pstats> ().knockbackmultiplier = 1;
	}
}

public class MysticalOrb : BaseItem {
	GameObject go;
	public MysticalOrb(GameObject g)
	{
		go = g;
		ItemName = "Mystical Orb";
	}
	public override void Effect()
	{

	}

	public override void Stats ()
	{
		go.GetComponent<Pstats> ().sDamage += 3;
		go.GetComponent<Pstats> ().chargereg += 4;
	}
	public override void RevertStats ()
	{
		go.GetComponent<Pstats> ().sDamage -= 3;
		go.GetComponent<Pstats> ().chargereg -= 4;
	}
}



