using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pinventory : MonoBehaviour {
	void Update()
	{
		var go = GameObject.Find ("UI_Inventory");
		go.guiText.text = "";
		if (items.Count == 0)
						go.guiText.text = "No items";
				else {
		foreach (BaseItem item in items)
				go.guiText.text += "\n" + item.ItemName;
		}

	}

	public List<BaseItem> items;
	void Start () {
		items = new List<BaseItem>();
	}
	public void AddItem (BaseItem item)
	{
		items.Add (item);
		item.Effect ();
	}
	public void RemoveItem (BaseItem item)
	{
		items.Remove (item);
	}
}
