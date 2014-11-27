using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pinventory : MonoBehaviour {
	public string name;
	void Update()
	{
		name = spell.SpellName;
//		var go = GameObject.Find ("UI_Inventory");
//		go.guiText.text = "";
//		if (items.Count == 0)
//						go.guiText.text = "No items";
//				else {
//		foreach (BaseItem item in items)
//				go.guiText.text += "\n" + item.ItemName;
//		}
//		go = GameObject.Find ("UI_Stats");
//		go.guiText.text = "";
//		go.guiText.text = 
//				"Attack damage: " + gameObject.GetComponent<Pstats>().aDamage.ToString () + 
//				"\nSpell damage: " + gameObject.GetComponent<Pstats>().sDamage.ToString () + 
//				"\nAttack speed: " + gameObject.GetComponent<Pstats>().aSpeed.ToString () + 
//				"%\nHealth: " + gameObject.GetComponent<Pstats>().health.ToString () + 
//				"%\nMaxHealth: " + gameObject.GetComponent<Pstats>().maxhealth.ToString () + 
//				"\nMovement speed: " + gameObject.GetComponent<Pstats>().movement + 
//				"%\nCharges: " + gameObject.GetComponent<Pstats>().charges.ToString();

	}

	public List<BaseItem> items;
	public BaseSpell spell;
	void Start () {
		items = new List<BaseItem>();
	}
	public void AddItem (BaseItem item)
	{
		if (items.Count == 4) {
		    items [3] = item;
			return;
	    }	
		items.Add (item);
		item.Effect ();
		item.Stats ();
	}
	public void RemoveItem (BaseItem item)
	{
		items.Remove (item);
	}
}
