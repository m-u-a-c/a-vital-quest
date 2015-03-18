using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pinventory : MonoBehaviour
{
    public Sprite _Placeholder;
    public Sprite Chargebolt;
    public Sprite Peashooter;
    public Sprite Shield;
    public Sprite Grail;
    public Sprite Robe;
    public Sprite Hästsko;
    public Sprite Idol;
    public Sprite Boots;
    public Sprite Sockor;
    public Sprite Core_Charged;
    public Sprite Core_Uncharged;
    public Sprite Crest;
    public Sprite Water;
    public Sprite Orb;
    public Sprite Charm;
	public Sprite HPPot;


    public List<Image> slots;

    //    void Update()
    //   {
    //        spell.UpdateStats();
    //        name = spell.SpellName;

    public List<BaseItem> items = new List<BaseItem>();
    public List<BaseSpell> spells;
    public List<float> spell_cooldowns;
    public List<float> spell_cooldowns_left;

    public List<Timer> spell_cds;
    public int selected_spell = 0;
    public int selected_item = 0;
    public int spellcount;
    
    void Start()
    {
        items = new List<BaseItem>();
        spells = new List<BaseSpell>();
        spell_cds = new List<Timer>();
    }

    public void AddItem(BaseItem item)
    {
        Sprite sprite = null;

        if (items.Count == 6) 
            RemoveItem(items[5]);
        
        items.Add(item);
        item.Stats();

        switch (item.ItemName)
        {
            case "Holy Grail":
                sprite = Grail;
                break;
            case "Friar Tuck's Robe":
                sprite = Robe;
                break;
            case "Elixir of Life":
                sprite = Idol;
                break;
            case "Lucky Horseshoe":
                sprite = Hästsko;
                break;
            case "Boots of Urgency":
                sprite = Boots;
                break;
            case "Sturdy Socks":
                sprite = Sockor;
                break;
            case "Static Core":
                sprite = Core_Charged;
                break;
            case "Vampiric Crest":
                sprite = Crest;
                break;
			case "Tablet of Shadows":
				sprite = _Placeholder;
				break;
            case "Mystical Orb":
                sprite = Orb;
                break;
            case "Charm of Restoration":
                sprite = Charm;
                break;
			case "Zephyr Juice":
				sprite = HPPot;
				break;
        }
        slots[items.Count - 1].GetComponent<Image>().sprite = sprite;
    }

    public void RemoveItem(BaseItem item)
    {
        int id = 0;
        item.RevertStats();
        if (item.ItemName == "Elixir of Life")
        {
            AudioSource.PlayClipAtPoint(gameObject.GetComponent<Pattacks>().holyWater, gameObject.transform.position, 0.7f);
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item) id = i;
        }
        slots[id].GetComponent<Image>().sprite = _Placeholder;
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
        int id = spell_cds.Count;
        var timer = gameObject.AddComponent<Timer>();
        spell_cds.Add(timer);
        spell_cds[id].SetTimer(s.Cooldown, 1);
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
            case "Holy Water":
                sprite = Water;
                break;

        }
        GameObject.Find("Spell").GetComponent<Image>().sprite = sprite;
    }

	public bool CheckForItem(BaseItem ittem)
	{
		foreach (BaseItem i in items) {
			if (i.ItemName == ittem.ItemName) return true;		
		}
		return false;
	}

	public KeyCode CheckSlot(BaseItem ittem)
	{
		int id = 0;
		id = items.IndexOf (ittem);
		switch (id) {
		case 0:
			return KeyCode.Alpha0;
		case 1:
			return KeyCode.Alpha1;
		case 2:
			return KeyCode.Alpha2;
		case 3:
			return KeyCode.Alpha3;
		case 4:
			return KeyCode.Alpha4;
		case 5:
			return KeyCode.Alpha5;
		}
		return KeyCode.Alpha0;
	}

    public void Update()
    {
        if (items.Count != 0) foreach (BaseItem item in items) item.Effect();

        //foreach (BaseSpell s in spells) s.UpdateStats();
        for (int i = 0; i < spell_cooldowns_left.Count; i++) spell_cooldowns_left[i] -= Time.deltaTime;

        var cast = Physics2D.CircleCast(new Vector2(transform.renderer.bounds.center.x, transform.renderer.bounds.center.y - 1), 1, Vector2.zero, 0, LayerMask.GetMask("Items"));
        if (cast && cast.collider.gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().pickUpItem, GameObject.Find("Player").gameObject.transform.position);
            #region Items
            switch (cast.collider.gameObject.name)
            {
                case "PFChargebolt(Clone)":
                case "PFChargebolt":
                    AddSpell(new Chargebolt(gameObject));
                    break;
                case "PFTucksRobe(Clone)":
                case "PFTucksRobe":
                    AddItem(new FriarTucksRobe(gameObject));
                    break;
                case "PFShield(Clone)":
                case "PFShield":
                    AddSpell(new YaosShield(gameObject));
                    break;
                case "PFHolyGrail(Clone)":
                case "PFHolyGrail":
                    AddItem(new HolyGrail(gameObject));
                    break;
                case "PFMagicPeashooter(Clone)":
                case "PFMagicPeashooter":
                    AddSpell(new MagicPeashooter(gameObject));
                    break;
                case "PFBootsofUrgency(Clone)":
                case "PFBootsofUrgency":
                    AddItem(new BootsOfUrgency(gameObject));
                    break;
                case "PFIdol(Clone)":
                case "PFIdol":
                    AddItem(new GlassIdol(gameObject));
                    break;
                case "PFSturdySocks(Clone)":
                case "PFSturdySocks":
                    AddItem(new SturdySocks(gameObject));
                    break;
                case "PFHorseshoe(Clone)":
                case "PFHorseshoe":
                    AddItem(new LuckyHorseshoe(gameObject));
                    break;
                case "PFStaticCore(Clone)":
                case "PFStaticCore":
                    AddItem(new StaticCore(gameObject));
                    break;
                case "PFVampiricCrest(Clone)":
                case "PFVampiricCrest":
                    AddItem(new VampiricCrest(gameObject));
                    break;
                case "PFHolyWater(Clone)":
                case "PFHolyWater":
                    AddSpell(new HolyWater(gameObject));
                    break;
				case "PFTabletOfShadows(Clone)":
				case "PFTabletOfShadows":
					AddItem (new TabletOfShadows(gameObject));
					break;
                case "PFMysticalOrb(Clone)":
                case "PFMysticalOrb":
                    AddItem(new MysticalOrb(gameObject));
                    break;
                case "PFCharmofRestoration":
                case "PFCharmofRestoration(Clone)":
                    AddItem(new CharmOfRestoration(gameObject));
                    break;
				case "PFZephyrJuice":
				case "ZephyrJuice":
					AddItem(new ZephyrJuice(gameObject));
					break;
            } 
            #endregion
            Destroy(cast.collider.gameObject);
        }
        if (spells.Count > 1)
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && (selected_spell + 1) != spells.Count)
            {
                selected_spell++;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && selected_spell > 0)
            {
                selected_spell--;
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
            case "Holy Water":
                sprite = Water;
                break;
        }
        GameObject.Find("Spell").GetComponent<Image>().sprite = sprite;
    }
}

