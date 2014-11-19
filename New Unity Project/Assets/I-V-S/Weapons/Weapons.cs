using UnityEngine;
using System.Collections;

public class SharpenedShovel : BaseWeapon{
	GameObject go;
	public SharpenedShovel(GameObject g)
	{
		go = g;
		WeaponName = "Sharpened Shovel";
	}
	public override void Effect ()
	{
		throw new System.NotImplementedException ();
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage * 1.5f;
		Speed = go.GetComponent<Pstats> ().aSpeed;
	}
}

public class HeavensHammer : BaseWeapon{
	GameObject go;
	public HeavensHammer(GameObject g){
		go = g;
		WeaponName = "Heaven's Hammer";
	}
	public override void Effect ()
	{
		//TODO: yes..
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage * 1.2f;
		Speed = go.GetComponent<Pstats> ().aSpeed * 1.1f;
	}
}

public class Pike : BaseWeapon{
	GameObject go;
	public Pike(GameObject g){
		go = g;
		WeaponName = "Pike";
	}
	public override void Effect ()
	{
		//TODO: jepp...........
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage * 1.1f;
		Speed = go.GetComponent<Pstats> ().aSpeed * 0.85f;
	}
}

public class ReapersScythe : BaseWeapon{
	GameObject go;
	public ReapersScythe(GameObject g){
		go = g;
		WeaponName = "Reaper's Scythe";
	}
	public override void Effect ()
	{
		//TODO: jepp...........
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage * 0.8f;
		Speed = go.GetComponent<Pstats> ().aSpeed * 1.3f;
	}
}

public class Greatsword : BaseWeapon{
	GameObject go;
	public Greatsword(GameObject g){
		go = g;
		WeaponName = "Greatsword";
	}
	public override void Effect ()
	{
		//TODO: Can't use spells
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage * 2;
		Speed = go.GetComponent<Pstats> ().aSpeed * 0.8f;
	}
}

public class ChargedBlade : BaseWeapon{
	GameObject go;
	public ChargedBlade(GameObject g){
		go = g;
		WeaponName = "Charged Blade";
	}
	public override void Effect ()
	{
		//TODO: Toggle thingy
	}
	public override void Stats ()
	{
		Damage = go.GetComponent<Pstats> ().aDamage;
		Speed = go.GetComponent<Pstats> ().aSpeed;
	}
}
