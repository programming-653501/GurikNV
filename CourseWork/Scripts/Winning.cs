using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour 
{

	public GameObject WinScreen;
	public GameObject MyCamera;
	public Hands Hands;
	public Text Text;
	public float timer = 10f;

	public bool WS = false;

	public void Win (int Direction)
	{
		WinScreen.SetActive (true);
		MyCamera.SetActive (false);
		Text.text = Hands.Names[Direction] + " won!";
		WS = true;
		File.Delete (@"1000Save.gsf");
		timer = 5f;
	}

	void Update ()
	{
		if (WS) 
		{
			timer -= Time.deltaTime;
			if (timer < 0) Application.LoadLevel ("MainScene");
		}
	}
}
