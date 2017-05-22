using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

	public List<GameObject>[] CardsHeld = new List<GameObject>[3];
	public string[] Names = { "Player1", "Player2" };

	void Start ()
	{
		for (int i = 0; i < 3; i++) 
		{
			CardsHeld [i] = new List<GameObject> ();
		}
	}

	public void ShowCards (int i)
	{
		foreach (var card in CardsHeld[i])
			card.SetActive (true);
	}

	public void HideCards (int i)
	{
		foreach (var card in CardsHeld[i])
			card.SetActive (false);
	}
}
