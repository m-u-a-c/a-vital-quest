using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ManualScript : MonoBehaviour {

	Canvas canvas;
	
	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
					showControls ();
	}
	
	public void showControls()
	{
		canvas.enabled = !canvas.enabled;
	}
}
