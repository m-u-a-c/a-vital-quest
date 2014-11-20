using UnityEngine;
using System.Collections;

public class OverlayUI : MonoBehaviour
{
	public Texture hämta;
	void OnGUI ()
	{
		if(GUI.Button(new Rect(Screen.width/1.15f,Screen.height/1.25f,128,116), hämta))
		{
			return;
		}
	}
}
