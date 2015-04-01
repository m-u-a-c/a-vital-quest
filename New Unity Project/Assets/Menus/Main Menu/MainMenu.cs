using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public AudioClip buttonClick;
	public void PlaySound()
	{
		AudioSource.PlayClipAtPoint(buttonClick, gameObject.transform.position, 0.4f); 
	}

	public void Loadlevel()
	{
		Application.LoadLevel (1);
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
