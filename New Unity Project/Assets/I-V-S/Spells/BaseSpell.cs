using UnityEngine;
using System.Collections;

public abstract class BaseSpell {
	public string SpellName {get; set;}
    public static float dmg = 5;
	public bool Left {
				get;
				set;
	}
	public float Cost {
				get;
				set;
	}
	public float Cooldown {
				get;
				set;
	}
	public float Damage {
				get;
				set;
	}
	abstract public void Effect ();
	abstract public void UpdateStats ();
}
