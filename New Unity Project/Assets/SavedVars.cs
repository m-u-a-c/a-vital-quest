using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Items;

public class SavedVars : MonoBehaviour
{

    public List<BaseItem> items = new List<BaseItem>();
    public List<BaseSpell> spells = new List<BaseSpell>();
    public BaseClassItem ClassItem;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
