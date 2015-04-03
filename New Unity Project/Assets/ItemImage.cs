using UnityEngine;
using System.Collections;

public class ItemImage : MonoBehaviour
{
    public int Slot;
    private Pinventory pinv;
    void Start()
    {
        pinv = GameObject.Find("Player").GetComponent<Pinventory>();
    }
    void OnMouseEnter()
    {
        if (Slot == 6) 
            pinv.ShowItemDes(pinv.ClassItem.ItemDescription);
        if (Slot == 7)
            pinv.ShowItemDes(pinv.spells[pinv.selected_spell].SpellDescription);
        if (pinv.items.Count > Slot) pinv.ShowItemDes(pinv.items[Slot].ItemDescription);
    }

    void OnMouseExit()
    {
        pinv.HiteItemDes();
    }
}
