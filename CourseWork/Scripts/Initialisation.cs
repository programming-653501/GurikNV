using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Initialisation : MonoBehaviour 
{
	public MainInfo MainInfo;
	public GameObject Panel;
	public GameObject Name1;
	public GameObject Name2;
	public GameObject Score1;
	public GameObject Score2;

	public void Init ()
	{
		if (!File.Exists (@"1000Save.gsf")) { File.Create (@"1000Save.gsf"); } 
		for (int i = 0; i < 2; i++) { MainInfo.Scores[i] = 0; }
		MainInfo.Barrel[0] = false;
		MainInfo.Barrel[1] = false;
		MainInfo.StartingTurn = 0;

		Panel.SetActive (true);
		MainInfo.Flags.Preparations = true;
	}
}
