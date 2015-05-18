using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseBehaviour : MonoBehaviour {

	Canvas canvas;

	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
			Pause();
	}

	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Math.Abs(Time.timeScale) < 1 ? 1 : 0;
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
