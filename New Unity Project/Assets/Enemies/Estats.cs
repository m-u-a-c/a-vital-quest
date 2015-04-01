using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.UI;

public class Estats : MonoBehaviour {
	//hittin
	public float aDamage = 10.0f;
	public float health = 20.0f;
	public float aSpeed = 3.0f;

	public bool isHit = false;

	void Start ()
	{
	
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

	public int getHit(float damageTaken, bool knockback = true)
	{
		health -= damageTaken;
		if (knockback) StartCoroutine ("Knockbacked");
        #region Sadism
        if (GameObject.Find("Player").GetComponent<Pinventory>().ClassItem != null)
            if (GameObject.Find("Player").GetComponent<Pinventory>().ClassItem.ItemName == "Sadism")
            {
                GetComponent<Pstats>().movement += 0.2f;
                GetComponent<Pstats>().healthreg += 0.3f;
                var t = GameObject.Find("Player").AddComponent<Timer>();
                t.SetTimer(2, 1, () =>
                {
                    GetComponent<Pstats>().movement -= 0.2f;
                    GetComponent<Pstats>().healthreg -= 0.3f;
                    Destroy(t);
                });
            }
        #endregion
        var text = (GameObject) Instantiate(Resources.Load("Other/Text"));
	    var gopos = gameObject.transform.position;
	    var textcomp = text.GetComponent<TextMesh>();
	    text.transform.position = new Vector3(gopos.x + 1f, gopos.y + 2, -1);
        textcomp.text = damageTaken.ToString();
        


	    return gameObject.GetInstanceID();
	}

	IEnumerator Knockbacked()
	{
		isHit = true;
		yield return new WaitForSeconds(0.5f);
		isHit = false;
	}
}
