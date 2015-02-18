using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public void Loadlevel()
	{
		Application.LoadLevel (1);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
