using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour 
{
	public Hands Hands;
	public MainInfo MainInfo;

	public bool CheckForSet (char suit, int player)
	{
		int k = 0;
		foreach (var card in Hands.CardsHeld[player]) 
		{
			CardScript Values = card.GetComponent<CardScript>();
			if (Values.suit == suit && (Values.value == 3 || Values.value == 4)) { k++; }
		}
		return (k == 2);
	}

	public bool CheckForSuit (char suit, int player)
	{
		foreach (var card in Hands.CardsHeld[player]) 
		{
			CardScript Values = card.GetComponent<CardScript>();
			if (Values.suit == suit) { return true; }
		}
		return false;
	}

	public bool CheckForTrump (char suit, int player)
	{
		foreach (var card in Hands.CardsHeld[player]) 
		{
			CardScript Values = card.GetComponent<CardScript>();
			if (Values.suit == MainInfo.Trump) { return true; }
		}
		return false;
	}
}
