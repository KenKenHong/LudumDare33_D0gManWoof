using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	public Canvas exitScreen;
	public Canvas optionScreen;
	public Canvas helpScreen;
	public Button startButton;
	public Button optionButton;
	public Button helpButton;
	public Button exitButton;

	public void Start ()
	{
		exitScreen = exitScreen.GetComponent<Canvas>();
		optionScreen = optionScreen.GetComponent<Canvas> ();
		helpScreen = helpScreen.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button>();
		optionButton = optionButton.GetComponent<Button>();
		helpButton = helpButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button>();
		exitScreen.enabled = false;
		optionScreen.enabled = false;
		helpScreen.enabled = false;
	}

	public void optionPress()
	{
		optionScreen.enabled = true;
		startButton.enabled = false;
		optionButton.enabled = false;
		helpButton.enabled = false;
		exitButton.enabled = false;
	}

	public void xPress ()
	{
		optionScreen.enabled = false;
		helpScreen.enabled = false;
		startButton.enabled = true;
		optionButton.enabled = true;
		helpButton.enabled = true;
		exitButton.enabled = true;
	}

	public void helpPress()
	{
		helpScreen.enabled = true;
		startButton.enabled = false;
		optionButton.enabled = false;
		helpButton.enabled = false;
		exitButton.enabled = false;
	}

	public void exitPress()
	{
		exitScreen.enabled = true;
		startButton.enabled = false;
		optionButton.enabled = false;
		helpButton.enabled = false;
		exitButton.enabled = false;
	}

	public void noPress()
	{
		exitScreen.enabled = false;
		startButton.enabled = true;
		optionButton.enabled = true;
		helpButton.enabled = true;
		exitButton.enabled = true;
	}

	public void startGame()
	{
		Application.LoadLevel (1);
	}

	public void exitGame()
	{
		Application.Quit ();
	}
}
