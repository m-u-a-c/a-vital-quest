using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void LoadMainMenu()
	{
		Application.LoadLevel ("Main menu");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
