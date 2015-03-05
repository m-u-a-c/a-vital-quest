using UnityEngine;
using System.Collections;

public abstract class BaseItem {
	public string ItemName {get; set;}
    //NOTE: Effect is called once per frame
    abstract public void Effect();
	abstract public void Stats ();
	abstract public void RevertStats ();
}
