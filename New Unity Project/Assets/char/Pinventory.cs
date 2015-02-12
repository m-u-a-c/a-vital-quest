using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pinventory : MonoBehaviour
{
    public Sprite Chargebolt;
    public Sprite Peashooter;
    public Sprite Shield;
    // void Update()
    // {

    // DEBUG
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

    // }

    public List<BaseItem> items;
    public List<BaseSpell> spells;
    public float[] spells_cooldowns = new float[3];
    public int selected_spell = 0;
    public int selected_item = 0;

    void Start()
    {
        items = new List<BaseItem>();
        spells = new List<BaseSpell>();
    }
    public void AddItem(BaseItem item)
    {
        if (items.Count == 4)
        {
            items[3] = item;
            return;
        }
        items.Add(item);
        item.Effect();
        item.Stats();
    }
    public void RemoveItem(BaseItem item)
    {
        item.RevertStats();
        items.Remove(item);
    }
    public void AddSpell(BaseSpell s)
    {
        if (spells.Count == 3)
        {
            spells[2] = s;
            return;
        }

        spells.Add(s);
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
    public void Update()
    {
        //foreach (BaseSpell s in spells) s.UpdateStats();

        int num;
        //if (Event.current.type == EventType.KeyDown)
        //{
        //    // Convert to numeric value for convenience :)
        //    num = Event.current.keyCode - KeyCode.Alpha1 + 1;
        //    if (num < 7 && num > 0) selected_item = num;
        //}
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && selected_spell < 2) selected_spell++;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && selected_spell > 0) selected_spell--;

        Sprite sprite = null;
        switch (spells[selected_spell].SpellName)
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

