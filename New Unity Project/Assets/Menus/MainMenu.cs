using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Texture btnTexture;
	void OnGUI ()
	{
		GUI.Box(new Rect(100,100,100,90), "A Vital Quest");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(125,150,100,50), "START GAME")) {
			Application.LoadLevel(1);
		}
	}
}
