using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Items;
using System;
using System.Linq;
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
    public Sprite Barrier;
    public Sprite Beam;
    public Sprite MerlinBand;
    public Sprite HerculesBand;
    public Sprite Sadism;
    public Sprite Masochism;

    private Text ADMG, SDMG, MSPEED, CRIT, HPTEXT, CHTEXT, CDTEXT, ItemDes;
    

    public List<Image> slots;
    private Image classImage, LeftSpell, RightSpell, PanelDes;

    public List<BaseItem> items = new List<BaseItem>();
    public List<BaseSpell> spells;
    public List<float> spell_cooldowns;
    public List<float> spell_cooldowns_left;
    public BaseClassItem ClassItem;
    public UnityEngine.Object[] pfitems;
    public UnityEngine.Object[] pfspells;

    public List<Timer> spell_cds;
    public int selected_spell = 0;
    public int selected_item = 0;
    public int spellcount;


    void Start()
    {
        ADMG = GameObject.Find("ADMG").GetComponent<Text>();
        SDMG = GameObject.Find("SDMG").GetComponent<Text>();
        MSPEED = GameObject.Find("MSPEED").GetComponent<Text>();
        CRIT = GameObject.Find("CRIT").GetComponent<Text>();
        HPTEXT = GameObject.Find("HPText").GetComponent<Text>();
        CHTEXT = GameObject.Find("CHText").GetComponent<Text>();
        CDTEXT = GameObject.Find("CDText").GetComponent<Text>();
        classImage = GameObject.Find("Spell").GetComponent<Image>();
        LeftSpell = GameObject.Find("LeftSpell").GetComponent<Image>();
        RightSpell = GameObject.Find("RightSpell").GetComponent<Image>();
        ItemDes = GameObject.Find("ItemDes").GetComponent<Text>();
        PanelDes = GameObject.Find("DesPanel").GetComponent<Image>();
        
        pfitems = Resources.LoadAll("Items/Items");
        pfspells = Resources.LoadAll("Items/Spells");

        items = new List<BaseItem>();
        spells = new List<BaseSpell>();
        spell_cds = new List<Timer>();
    }

    public void SetClassItem(BaseClassItem classitem)
    {
        if (ClassItem != null) ClassItem.RevertStats();
        ClassItem = classitem;
        ClassItem.Stats();
        var img = GameObject.Find("ClassItem").GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        switch (classitem.ItemName)
        {
            case "Sadism":
                img.sprite = Sadism;
                break;
            case "Masochism":
                img.sprite = Masochism;
                break;
        }
        ShowText(classitem.ItemName, Color.red);
    }

    public void ShowText(string name, Color color)
    {
        
        var text = GameObject.Find("ItemText");
        text.GetComponent<Text>().text = name;
        var textcolor = text.GetComponent<Text>().color;
        textcolor = color;
        textcolor = new Color(textcolor.r, textcolor.g, textcolor.b, 0);
        text.GetComponent<Text>().color = textcolor;
        var timer1 = text.AddComponent<Timer>();
        var timer2 = text.AddComponent<Timer>();
        timer1.SetTimer(0.001f, 80, () =>
        {
            if (textcolor.a <= 1) textcolor = new Color(textcolor.r, textcolor.g, textcolor.b, textcolor.a + 0.1f);
            text.GetComponent<Text>().color = textcolor;
            if (timer1.ticks >= 80)
                timer2.SetTimer(0.05f, 20, () =>
                {
                    if (textcolor.a >= 0) textcolor = new Color(textcolor.r, textcolor.g, textcolor.b, textcolor.a - 0.1f);
                    text.GetComponent<Text>().color = textcolor;
                });
        });
    }

    public void AddItem(BaseItem item)
    {
        Sprite sprite = null;
        ShowText(item.ItemName, Color.yellow);


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
            case "Merlin's Band of Fate":
                sprite = MerlinBand;
                break;
            case "Hercules' Band of Power":
                sprite = HerculesBand;
                break;
            case "Sadism":
                sprite = Sadism;
                break;
            case "Masochism":
                sprite = Masochism;
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
        ShowText(s.SpellName, Color.cyan);
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
            case "Barrier":
                sprite = Barrier;
                break;
            case "Photon Beam":
                sprite = Beam;
                break;
        }
        GameObject.Find("Spell").GetComponent<Image>().sprite = sprite;
    }

    public BaseSpell GetSpell(System.Type type)
    {
        foreach (BaseSpell bs in spells)
        {
            if (bs.GetType() == type)
            {
                return bs;
            }
        }
        return null;
    }

    public bool CheckForItem(BaseItem ittem)
    {
        return items.Any(i => i.ItemName == ittem.ItemName);
    }

    public KeyCode CheckSlot(BaseItem ittem)
    {
        int id = 0;
        id = items.IndexOf(ittem);
        switch (id)
        {
            case 0:
                return KeyCode.Alpha1;
            case 1:
                return KeyCode.Alpha2;
            case 2:
                return KeyCode.Alpha3;
            case 3:
                return KeyCode.Alpha4;
            case 4:
                return KeyCode.Alpha5;
            case 5:
                return KeyCode.Alpha6;
        }
        return KeyCode.Alpha0;
    }

    public void Update()
    {
        var pstats = GameObject.Find("Player").GetComponent<Pstats>();
        ADMG.text = pstats.aDamage.ToString();
        SDMG.text = pstats.sDamage.ToString();
        MSPEED.text = (pstats.movement * 100).ToString() + "%";
        CRIT.text = (pstats.critchance).ToString() + "%";
        HPTEXT.text = Mathf.RoundToInt(pstats.health) + " / " +
                                                              Mathf.RoundToInt(pstats.maxhealth);
        CHTEXT.text = Mathf.RoundToInt(pstats.charges) + " / " +
                                                          Mathf.RoundToInt(pstats.maxcharges);

        foreach (var slot in slots) slot.color = slot.sprite == null ? new Color(slot.color.r, slot.color.g, slot.color.b, 0) : new Color(slot.color.r, slot.color.g, slot.color.b, 1);

        classImage.color = classImage.sprite == null ? new Color(classImage.color.r, classImage.color.g, classImage.color.b, 0) : new Color(classImage.color.r, classImage.color.g, classImage.color.b, 1);

        if (spells != null && spells.Count > 0)
            if (spell_cds[selected_spell].running)
            {
                CDTEXT.color = new Color(CDTEXT.color.r, CDTEXT.color.g, CDTEXT.color.b, 1);
                CDTEXT.text = Math.Round(spell_cds[selected_spell].Totaltimeleft, 1).ToString();
            }
            else
            {
                CDTEXT.color = new Color(CDTEXT.color.r, CDTEXT.color.g, CDTEXT.color.b, 0);
            }



        if (items.Count != 0) foreach (var item in items) item.Effect();
        if (ClassItem != null) ClassItem.Effect();

        var cast = Physics2D.OverlapArea(new Vector2(transform.renderer.bounds.center.x - transform.renderer.bounds.size.x / 2, transform.renderer.bounds.center.y), new Vector2(transform.renderer.bounds.center.x + transform.renderer.bounds.size.x / 2, transform.renderer.bounds.center.y - 1), LayerMask.GetMask("Items"));
        if (cast && cast.gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(gameObject.GetComponent<Pattacks>().pickUpItem, GameObject.Find("Player").gameObject.transform.position);
            #region Items

            switch (cast.gameObject.name)
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
                    AddItem(new TabletOfShadows(gameObject));
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
                case "PFBarrier":
                case "PFBarrier(Clone)":
                    AddSpell(new Barrier(gameObject));
                    break;
                case "PFLaser":
                case "PFLaser(Clone)":
                    AddSpell(new PhotonBeam(gameObject));
                    break;
                case "PFMerlinBand":
                case "PFMerlinBand(Clone)":
                    AddItem(new MerlinsBandofFate((gameObject)));
                    break;
                case "PFHerculesBand":
                case "PFHerculesBand(Clone)":
                    AddItem((new HerculesBandofPower(gameObject)));
                    break;
                case "PFSadism":
                case "PFSadism(Clone)":
                    SetClassItem(new Sadism(gameObject));
                    break;
                case "PFMasochism":
                case "PFMasochism(Clone)":
                    SetClassItem(new Masochism(gameObject));
                    break;
            }
            #endregion
            Destroy(cast.gameObject);
        }
        if (spells != null && spells.Count > 1)
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
        if (spells.Count > 0)
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
                case "Barrier":
                    sprite = Barrier;
                    break;
                case "Photon Beam":
                    sprite = Beam;
                    break;
            }
        GameObject.Find("Spell").GetComponent<Image>().sprite = sprite;
    }

    public void ShowItemDes(string text)
    {
        ItemDes.text = text;
        PanelDes.color = new Color(PanelDes.color.r, PanelDes.color.g, PanelDes.color.b, 100f/255f);
        ItemDes.color = new Color(ItemDes.color.r, ItemDes.color.g, ItemDes.color.b, 1);
    }

    public void HiteItemDes()
    {
        PanelDes.color = new Color(PanelDes.color.r, PanelDes.color.g, PanelDes.color.b, 0);
        ItemDes.color = new Color(ItemDes.color.r, ItemDes.color.g, ItemDes.color.b, 0);
    }
}