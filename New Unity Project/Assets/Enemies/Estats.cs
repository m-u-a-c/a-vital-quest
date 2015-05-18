using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.UI;

public class Estats : MonoBehaviour {
	//hittin
	public float aDamage = 10.0f;
	public float health = 20.0f;
	public float aSpeed = 3.0f;
    private Pstats pstats;
    private GameObject player;
	public bool isHit = false;

	void Start ()
	{
	    pstats = GameObject.Find("Player").GetComponent<Pstats>();
	    player = GameObject.Find("Player");
	}

	void Update ()
	{

		if (health <= 0) 
		{
			GameObject.Find ("Observer").GetComponent<Observer> ().RemoveEnemy();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (GameObject.Find ("Player").GetComponent<Pattacks>().enemySplat, gameObject.transform.position, 0.15f);
		}
	}

    bool CheckForBuff()
    {
        return player.GetComponents<Timer>().Any(ti => ti.Id == 1);
    }

    public int getHit(float damageTaken, bool knockback = true, bool crit = false)
	{
		health -= damageTaken;
		if (knockback) StartCoroutine ("Knockbacked");
        #region Sadism
        if (player.GetComponent<Pinventory>().ClassItem != null)
            if (player.GetComponent<Pinventory>().ClassItem.ItemName == "Sadism" && !CheckForBuff()) 
            {
                pstats.movement += 0.2f;
                pstats.healthreg += 0.1f;
                var t = player.AddComponent<Timer>();
                t.SetTimer(2, 1, () =>
                {
                    pstats.movement -= 0.2f;
                    pstats.healthreg -= 0.1f;
                    Destroy(t);
                });
                t.Id = 1;
            }
        #endregion
        var text = (GameObject) Instantiate(Resources.Load("Other/Text"));
	    var gopos = gameObject.transform.position;
	    var textcomp = text.GetComponent<TextMesh>();
        if (crit) 
        {
            textcomp.color = Color.red;
            text.transform.localScale *= 1.5f;
        } 
        
	    text.transform.position = new Vector3(gopos.x + 1f, gopos.y + 2, -5);
        textcomp.text = Math.Round(damageTaken, 1).ToString();
        


	    return gameObject.GetInstanceID();
	}

	IEnumerator Knockbacked()
	{
		isHit = true;
		yield return new WaitForSeconds(0.5f);
		isHit = false;
	}
}
