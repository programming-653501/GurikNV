using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour 
{
	public MainInfo MainInfo;
	public GameObject Button;
	public GameObject AnotherButton;
	public GameObject Panel;
	public GameObject ExitButton;
	public GameObject MainMenuButton;

	void Start () 
	{
		if (!File.Exists (@"1000Save.gsf"))
			Button.SetActive (false);
	}

	void OnMouseUp ()
	{
		Load ();
		AnotherButton.SetActive (false);
		Button.SetActive (false);
		ExitButton.SetActive (false);
		MainMenuButton.SetActive (true);
	}

	void Load () 
	{
		string RawLoaded = File.ReadAllText(@"1000Save.gsf");
		var Loaded = RawLoaded.Split ('~');

		MainInfo.StartingTurn = int.Parse(Loaded[0]);
		for (int i = 1; i < 3; i++) { MainInfo.Scores[i - 1] = int.Parse(Loaded[i]); }
		MainInfo.Bolts [0] = int.Parse (Loaded [3]);
		MainInfo.Bolts [1] = int.Parse (Loaded [4]);
		MainInfo.Barrel [0] = bool.Parse (Loaded [5]);
		MainInfo.Barrel [1] = bool.Parse (Loaded [6]);
		MainInfo.Barrels [0] = int.Parse (Loaded [7]);
		MainInfo.Barrels [1] = int.Parse (Loaded [8]);
		MainInfo.SessionsOnBarrel [0] = int.Parse (Loaded [9]);
		MainInfo.SessionsOnBarrel [1] = int.Parse (Loaded [10]);

		Panel.SetActive (true);
		MainInfo.Flags.Preparations = true;
	}
}
