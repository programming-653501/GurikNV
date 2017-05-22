using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pass : MonoBehaviour 
{
	public Rules Rules;
	public MainInfo MainInfo;
	public PlayerSwapper PlayerSwapper;
	public Hands Hands;
	public GameObject TradePanel;
	public Text Text;
	public GameObject ScoresPanel;
	public Text StageText;

	void OnMouseUp () 
	{
		if (MainInfo.Flags.Trade) 
		{
			MainInfo.Flags.Trade = false;
			MainInfo.Flags.ReserveGiveaway = true;
			MainInfo.CurrentTurn = (MainInfo.CurrentTurn + 1) % 2;
			MainInfo.CurrentStartingTurn = MainInfo.CurrentTurn;
			PlayerSwapper.Swap (MainInfo.CurrentTurn);

			GiveReserve ();

			Text.text = "Proceed";
		}
		else if (MainInfo.Flags.ReserveGiveaway)
		{
			if (CardScript.CardsGiven == 2) 
			{
				CardScript.CardsGiven = 0;

				MainInfo.Flags.ReserveGiveaway = false;
				MainInfo.Flags.Game = true;
				TradePanel.SetActive (false);
				ScoresPanel.SetActive (true);
				StageText.text = "Play";
				MainInfo.OnBet = MainInfo.CurrentTurn;

				Text.text = "Pass";
			}
		}
	}
		
	void GiveReserve ()
	{
		for (int i = 0; i < 4; i++) 
		{
			Hands.CardsHeld [MainInfo.CurrentTurn].Add (Hands.CardsHeld[2][0]);
			Hands.CardsHeld [2].RemoveAt (0);
			Hands.CardsHeld [MainInfo.CurrentTurn][10 + i].transform.position = new Vector2 ((float)(4f + 1.2f * (i)), -4f);
		}
		MainInfo.MaxBet [MainInfo.CurrentTurn] = 120;
		if (Rules.CheckForSet ('♥', MainInfo.CurrentTurn))
			MainInfo.MaxBet [MainInfo.CurrentTurn] += 100;
		if (Rules.CheckForSet ('♦', MainInfo.CurrentTurn))
			MainInfo.MaxBet [MainInfo.CurrentTurn] += 80;
		if (Rules.CheckForSet ('♣', MainInfo.CurrentTurn))
			MainInfo.MaxBet [MainInfo.CurrentTurn] += 60;
		if (Rules.CheckForSet ('♠', MainInfo.CurrentTurn))
			MainInfo.MaxBet [MainInfo.CurrentTurn] += 40;
	}
}
