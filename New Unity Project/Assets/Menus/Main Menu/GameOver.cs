using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void LoadMainMenu()
	{
		Application.LoadLevel (0);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
