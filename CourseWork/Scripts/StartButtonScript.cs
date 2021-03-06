using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour 
{
	public Initialisation Initialisation;
	public GameObject Button;
	public GameObject AnotherButton;
	public GameObject ExitButton;
	public GameObject MainMenuButton;

	void OnMouseUp ()
	{
		AnotherButton.SetActive (false);
		Button.SetActive (false);
		ExitButton.SetActive (false);
		MainMenuButton.SetActive (true);
		Initialisation.Init();
	}
}
