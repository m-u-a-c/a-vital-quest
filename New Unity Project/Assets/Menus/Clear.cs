using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	Canvas canvas;
	
	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	void Update ()
	{
	
	}

	public void Show()
	{
		canvas.enabled = true;
	}
}
