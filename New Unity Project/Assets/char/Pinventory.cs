using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pinventory : MonoBehaviour
{
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

//    void Update()
//   {
//        spell.UpdateStats();
//        name = spell.SpellName;
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
    public List<float> spell_cooldowns;
    public List<float> spell_cooldowns_left;
    public int selected_spell = 0;
    public int selected_item = 0;
    public int spellcount;
    void Start()
    {
        items = new List<BaseItem>();
        spells = new List<BaseSpell>();
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
    public void AddSpell(BaseSpell s)
    {
        if (spells.Count == 3)
        {
            spells[selected_spell] = s;
            return;
        }

        spells.Add(s);
        spell_cooldowns_left.Add(s.Cooldown);
        spell_cooldowns.Add(s.Cooldown);
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
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector2(transform.renderer.bounds.center.x, transform.renderer.bounds.center.y - 1), 1);
    }
    public void Update()
    {
        //foreach (BaseSpell s in spells) s.UpdateStats();
        for (int i = 0; i < spell_cooldowns_left.Count; i++) spell_cooldowns_left[i] -= Time.deltaTime;

        var cast = Physics2D.CircleCast(new Vector2(transform.renderer.bounds.center.x, transform.renderer.bounds.center.y - 1), 1, Vector2.zero, 0, LayerMask.GetMask("Items"));
        if (cast && cast.collider.gameObject.tag == "Item" && Input.GetKey(KeyCode.E))
        {
            SendMessage("asd");
            switch (cast.collider.gameObject.name)
            {
                case "PFChargebolt(Clone)":
                    AddSpell(new Chargebolt(gameObject));
                    break;
                case "PFTucksRobe(Clone)":
                    AddItem(new FriarTucksRobe(gameObject));
                    break;
                case "PFShield(Clone)":
                    AddSpell(new YaosShield(gameObject));
                    break;
                case "PFHolyGrail(Clone)":
                    AddItem(new HolyGrail(gameObject));
                    break;
                case "PFMagicPeashooter(Clone)":
                    AddSpell(new MagicPeashooter(gameObject));
                    break;
            }
            Destroy(cast.collider.gameObject);
        }
        else if (cast && cast.collider.gameObject.tag == "Item" && GetComponent<Movement>().grounded)
        {
//            cast.collider.gameObject.rigidbody2D.AddForce(new Vector2(0, 60));
        }

        //int num;
        //if (Event.current.type == EventType.KeyDown)
        //{
        //    // Convert to numeric value for convenience :)
        //    num = Event.current.keyCode - KeyCode.Alpha1 + 1;
        //    if (num < 7 && num > 0) selected_item = num;
        //}
        if (spells.Count > 1)
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && (selected_spell + 1) != spells.Count)
		{
			selected_spell++;
			if(spells.Count == 2)
				selected_spell = 0;
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && selected_spell > 0)
		{
			selected_spell--;
			if(spells.Count == 0)
				selected_spell = 2;
		}
        spellcount = spells.Count;
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

