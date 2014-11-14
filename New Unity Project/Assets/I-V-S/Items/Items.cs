using UnityEngine;
using System.Collections;

public class HolyGrail : BaseItem  {
	GameObject go;
	public HolyGrail(GameObject g)
	{
		go = g;
	}
	public override void Effect ()
	{
		ItemName = "Holy Grail";
		go.GetComponent<Pstats> ().health += 30;
		go.GetComponent<Pstats> ().healthreg += 5;
	}
}

public class LJRobe : BaseItem {
	GameObject go;
	
	public LJRobe(GameObject g)
	{
		go = g;
	}
	public override void Effect ()
	{
		ItemName = "Lil John's Robe";
		go.GetComponent<Pstats> ().charges += 2;
		go.GetComponent<Pstats> ().chargereg += 2;
	}
}

public class GlassIdol : BaseItem {
	GameObject go;
	public GlassIdol(GameObject g)
	{
		go = g;
	}
	public override void Effect ()
	{
		ItemName = "Glass Idol";
		//TODO: Restores you to full HP and Charges when brought below 10 HP. Breaks on effect.
	}
}

public class LuckyHorseshoe : BaseItem {
	GameObject go;
	public LuckyHorseshoe(GameObject g)
	{
		go = g;
	}
	public override void Effect()
	{
		ItemName = "Lucky Horseshoe";
		go.GetComponent<Pstats> ().critchance += 10;
	}
}

public class BootsOfUrgency : BaseItem {
	GameObject go;
	public BootsOfUrgency(GameObject g)
	{
		go = g;
	}
	public override void Effect()
	{
		ItemName = "Boots of Urgency";
		go.GetComponent<Pstats> ().attackspeed += 20;
		go.GetComponent<Pstats> ().movement += 20;
	}
}

public class SturdySocks : BaseItem {
	GameObject go;
	public SturdySocks(GameObject g)
	{
		go = g;
	}
	public override void Effect()
	{
		ItemName = "Sturdy Socks";
		go.GetComponent<Pstats> ().aDamage += 3;
		//TODO: Cannot get knocked back.
	}
}

public class MysticalOrb : BaseItem {
	GameObject go;
	public MysticalOrb(GameObject g)
	{
		go = g;
	}
	public override void Effect()
	{
		ItemName = "Mystical Orb";
		go.GetComponent<Pstats> ().sDamage += 3;
		go.GetComponent<Pstats> ().chargereg += 4;
	}
}



