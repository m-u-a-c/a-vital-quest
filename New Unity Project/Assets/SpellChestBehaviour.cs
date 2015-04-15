using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class SpellChestBehaviour : MonoBehaviour
{

    public LayerMask chests;
    public Transform chestCheck;
    Collider2D findChests;
    public float searchR = 2.0f;

    public Sprite chest_open;
    public bool open = false;
    public bool random = true;
    public GameObject prefab;
    System.Random rnd;

    void Start()
    {
        GetComponent<Animator>().SetBool("Active", true);
    }

    void Update()
    {
        findChests = Physics2D.OverlapCircle(chestCheck.position, searchR, chests);
        if (findChests)
        {
            OpenSesame();
        }
    }

    public void OpenSesame()
    {
        
        
        if (!open)
        {
            

            Destroy(gameObject.GetComponent<Animator>());
            AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().chestOpen, gameObject.transform.position, 0.4f);
            gameObject.GetComponent<SpriteRenderer>().sprite = chest_open;
            if (random)
            {
                var items = Resources.LoadAll("Items/Spells");
                var pfs = new System.Collections.Generic.List<GameObject>();
                foreach (var item in items) if (item.ToString().Contains("PF")) pfs.Add((GameObject)item);
                
                rnd = new System.Random(Guid.NewGuid().GetHashCode());
                int i = rnd.Next(0, pfs.Count - 1);
                GameObject go = (GameObject)Instantiate(Resources.Load("Items/Spells/" + pfs[i].name));
                go.transform.position = gameObject.transform.position;
                go.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, -1);
                go.rigidbody2D.AddForce(new Vector2(0, 500));
            }
            else
            {
                SpawnItem(prefab.name);
            }
            open = true;
        }
    }


    void SpawnItem(string itemname)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("Items/Spells/" + itemname));
        go.transform.position = gameObject.transform.position;
        go.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, -1);
        go.rigidbody2D.AddForce(new Vector2(0, 500));
    }
}
