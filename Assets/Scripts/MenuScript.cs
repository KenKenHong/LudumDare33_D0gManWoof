using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	public Canvas exitScreen;
	public Canvas optionScreen;
	public Canvas helpScreen;

	public void Start ()
	{
		exitScreen.enabled = false;
		optionScreen.enabled = false;
		helpScreen.enabled = false;
	}

	public void startGame()
	{
		exitScreen.enabled = false;
		optionScreen.enabled = false;
		helpScreen.enabled = false;
	}

	public void exitGame()
	{
		Application.Quit ();
	}
}