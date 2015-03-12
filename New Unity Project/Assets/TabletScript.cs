using UnityEngine;
using System.Collections;

public class TabletScript : MonoBehaviour {


	Timer timer;
	// Use this for initialization
	void Start () {
		timer = gameObject.AddComponent<Timer> ();
		timer.SetTimer (0.2f, 1, new System.Action (Hit));
	}

	void Hit()
	{

	}
}
