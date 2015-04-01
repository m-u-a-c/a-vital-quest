using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public AudioClip buttonClick;
	bool playing;
	public void PlaySound()
	{
		AudioSource.PlayClipAtPoint(buttonClick, gameObject.transform.position, 0.4f); 
	}

	public void Loadlevel()
	{
		AudioSource.PlayClipAtPoint(buttonClick, gameObject.transform.position, 0.4f); 
		playing = true;
		var timer = gameObject.AddComponent<Timer> ();
		timer.SetTimer (0.8f, 1, () => {playing = false; Application.LoadLevel (1);});
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
