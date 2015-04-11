using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class ChestBehaviour : MonoBehaviour
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
            AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().chestOpen, gameObject.transform.position, 0.4f);
            gameObject.GetComponent<SpriteRenderer>().sprite = chest_open;
            if (random)
            {
                rnd = new System.Random(Guid.NewGuid().GetHashCode());
                var items = Resources.LoadAll("Items/Items");
                var pfs = new System.Collections.Generic.List<GameObject>();
                foreach (var item in items) if (item.ToString().Contains("PF")) pfs.Add((GameObject)item);
                int i = rnd.Next(0, pfs.Count - 1);
                SpawnItem(pfs[i].name);
            }
            else
            {
                SpawnItem(prefab.name);
            }
            open = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //		rnd = new System.Random ();
        //		int i = rnd.Next (1, 5);
        //		if (coll.gameObject.name == "Player" && !open) {
        //						gameObject.GetComponent<SpriteRenderer> ().sprite = chest_open;
        //						AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().chestOpen, gameObject.transform.position, 0.7f);
        //		if (random) 
        //			{
        //			switch (i)
        //			{
        //			case 1:
        //				SpawnItem ("PFTucksRobe");
        //				break;
        //			case 2:
        //				SpawnItem ("PFHolyGrail");
        //				break;
        //			case 3:
        //				SpawnItem ("PFChargebolt");
        //				break;
        //			case 4:
        //				SpawnItem ("PFMagicPeashooter");
        //				break;
        //			}
        //			}
        //			else
        //			{
        //				SpawnItem (prefab.name);
        //			}
        //			open = true;
        //		}

    }

    void SpawnItem(string itemname)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("Items/Items/" + itemname));
        go.transform.position = gameObject.transform.position;
        go.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, -1);
        go.rigidbody2D.AddForce(new Vector2(0, 500));
    }
}
