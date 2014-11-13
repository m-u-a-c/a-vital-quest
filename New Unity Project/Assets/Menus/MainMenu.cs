using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Texture btnTexture;
	void OnGUI ()
	{
		GUI.Box(new Rect(Screen.width/2,Screen.height/4,100,90), "A Vital Quest");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,100,50), "START GAME")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/1.65f,100,50), "OPTIONS")) {
			//Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/1.40f,100,50), "EXIT GAME")) {
			Application.Quit();
		}
	}
}
