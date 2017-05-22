using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwapper : MonoBehaviour 
{
	public GameObject Transfer;
	public GameObject MyCamera;
	public MainInfo MainInfo;
	public Hands Hands;
	public Text Text;

	public bool transfer = false;

	public void Swap (int Direction)
	{
		Transfer.SetActive (true);
		MyCamera.SetActive (false);
		Hands.HideCards ((Direction + 1) % 2);
		Hands.ShowCards (Direction);
		Text.text = "Transfer device to " + Hands.Names[Direction] + " and press any key...";
		transfer = true;
	}
	void Update ()
	{
		if (transfer && Input.anyKeyDown) 
		{
			Transfer.SetActive (false);
			MyCamera.SetActive (true);
			transfer = false;
		}
	}
}
