using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pinventory : MonoBehaviour
{
    public string name;
    public Sprite Chargebolt;
    public Sprite Peashooter;
    public Sprite Shield;
	public Sprite Grail;
	public Sprite Robe;

	public Image Slot1;
	public Image Slot2;
	public Image Slot3;
	public Image Slot4;
	public Image Slot5;
	public Image Slot6;

    void Update()
    {
//        spell.UpdateStats();
//        name = spell.SpellName;

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

    void Start()
    {
        items = new List<BaseItem>();
    }
    public void AddItem(BaseItem item)
    {
		Sprite sprite = null;

        if (items.Count == 6)
        {
            items[5] = item;
            return;
        }
        items.Add(item);
        item.Effect();
        item.Stats();

		switch (item.ItemName)
		{
			case "Holy Grail":
					sprite = Grail;
					break;
			case "Friar Tuck's Robe":
					sprite = Robe;
					break;
		}

		if(items.Count == 1)
			GameObject.Find("Slot1").GetComponent<Image>().sprite = sprite;
		if(items.Count == 2)
			GameObject.Find("Slot2").GetComponent<Image>().sprite = sprite;
		if(items.Count == 3)
			GameObject.Find("Slot3").GetComponent<Image>().sprite = sprite;
		if(items.Count == 4)
			GameObject.Find("Slot4").GetComponent<Image>().sprite = sprite;
		if(items.Count == 5)
			GameObject.Find("Slot5").GetComponent<Image>().sprite = sprite;
		if(items.Count == 6)
			GameObject.Find("Slot6").GetComponent<Image>().sprite = sprite;
    }
    public void RemoveItem(BaseItem item)
    {
        item.RevertStats();
        items.Remove(item);
    }
    public void SetSpell(BaseSpell s)
    {
        spell = s;
        Sprite sprite = null;
        switch (s.SpellName)
        {
            case "Magic Peashooter":
                sprite = Peashooter;
                break;
            case "Chargebolt":
                sprite = Chargebolt;
                break;
            case "Yao's Shield":
                sprite = Shield;
                break;
        }
        GameObject.Find("Spell").GetComponent<Image>().sprite = sprite;
    }

}
