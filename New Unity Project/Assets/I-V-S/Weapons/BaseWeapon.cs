using UnityEngine;
using System.Collections;

public abstract class BaseWeapon {
	public string WeaponName {get; set;}
	public float Damage {get; set; }
	public float Speed {
				get;
				set;
	}
	abstract public void Effect ();
	abstract public void Stats ();

}
