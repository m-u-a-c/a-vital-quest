using UnityEngine;
using System.Collections;

public class CasterAttack : MonoBehaviour {


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Caster_AI AIscript = GetComponent<Caster_AI>();

		if(AIscript.inRange)
			Cast ();
	}

	void Cast()
	{
		//Castspell

	}


}
