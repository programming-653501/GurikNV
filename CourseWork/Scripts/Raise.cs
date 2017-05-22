using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raise : MonoBehaviour 
{
	public MainInfo MainInfo;
	public PlayerSwapper PlayerSwapper;

	void OnMouseUp ()
	{
		if (MainInfo.MaxBet[MainInfo.CurrentTurn] > MainInfo.bet)
		{
			MainInfo.bet += 5;
			if (MainInfo.Flags.Trade) 
			{ 
				MainInfo.CurrentTurn = (MainInfo.CurrentTurn + 1) % 2;
				PlayerSwapper.Swap (MainInfo.CurrentTurn); 
			}
		}
	}

}
