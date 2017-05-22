using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour 
{
	public int CardsOnBoardCounter = 0;
	public List<GameObject> CardsOnBoard;

	public MainInfo MainInfo;
	public PlayerSwapper PlayerSwapper;
	public Hands Hands;
	public Rules Rules;

	public float timer = 1f;

	public Text Score1;
	public Text Score2;
	public GameObject ScoresPanel;

	void Start ()
	{
		CardsOnBoard = new List<GameObject>();
	}

	void Update ()
	{
		if (MainInfo.Flags.SessionResults && timer <= 0)
		{
			SessionResults ();
		}
		if (MainInfo.Flags.SessionResults)timer -= Time.deltaTime;
	}

	int PlayerWon ()
	{
		if (CardsOnBoard [0].GetComponent<CardScript> ().suit == CardsOnBoard [1].GetComponent<CardScript> ().suit) 
		{
			if (CardsOnBoard [0].GetComponent<CardScript> ().value > CardsOnBoard [1].GetComponent<CardScript> ().value) 
			{
				return MainInfo.CurrentStartingTurn;
			}
			else
			{
				return (MainInfo.CurrentStartingTurn + 1) % 2;
			}
		}
		if (CardsOnBoard [1].GetComponent<CardScript> ().suit == MainInfo.Trump)
		{
			return (MainInfo.CurrentStartingTurn + 1) % 2;
		}
		else
		{
			return MainInfo.CurrentStartingTurn;
		}
	}

	void SessionResults ()
	{
		int SessionScores = 0;
		for (int i = 0; i < 2; i++) 
		{
			SessionScores += CardsOnBoard [i].GetComponent<CardScript> ().value;
		}
		int PW = PlayerWon ();
		MainInfo.CurrentScores [PW] += SessionScores;
		Score1.text = MainInfo.CurrentScores [0].ToString();
		Score2.text = MainInfo.CurrentScores [1].ToString();
		for (int i = 0; i < 2; i++) 
		{
			CardsOnBoard [i].transform.position = new Vector2 (24f, 0f);
		}
		for (int i = 0; i < 2; i++) 
		{
			CardsOnBoard[i].GetComponent<CardScript> ().isPlayed = false;
		}
		CardsOnBoard.Clear ();
		if (MainInfo.CardsPlayed < 24)
		{
			PlayerSwapper.Swap (PW);
			CardsOnBoardCounter = 0;
			MainInfo.CurrentStartingTurn = PW;
			MainInfo.CurrentTurn = PW;
			MainInfo.Flags.SessionResults = false;
			MainInfo.Flags.Game = true;
		}
		else
		{
			CardsOnBoardCounter = 0;
			MainInfo.CardsPlayed = 0;
			MainInfo.Trump = ' ';
			ScoresPanel.SetActive (false);
			MainInfo.Flags.SessionResults = false;
			MainInfo.Flags.Results = true;
		}
	}

	public void PlayCard (GameObject card)
	{
		card.GetComponent<CardScript> ().isPlayed = true;
		if (CardsOnBoardCounter == 0 && (card.GetComponent<CardScript> ().value == 3 || card.GetComponent<CardScript> ().value == 4) 
			&& (Rules.CheckForSet(card.GetComponent<CardScript> ().suit, MainInfo.CurrentTurn)) && MainInfo.CardsPlayed > 0) 
		{
			if (card.GetComponent<CardScript> ().suit == '♥') { MainInfo.Trump = '♥'; MainInfo.CurrentScores [MainInfo.CurrentTurn] += 100; }
			if (card.GetComponent<CardScript> ().suit == '♦') { MainInfo.Trump = '♦'; MainInfo.CurrentScores [MainInfo.CurrentTurn] += 80; }
			if (card.GetComponent<CardScript> ().suit == '♣') { MainInfo.Trump = '♣'; MainInfo.CurrentScores [MainInfo.CurrentTurn] += 60; }
			if (card.GetComponent<CardScript> ().suit == '♠') { MainInfo.Trump = '♠'; MainInfo.CurrentScores [MainInfo.CurrentTurn] += 40; }
		}

		card.transform.position = new Vector2(-0.6f + CardsOnBoardCounter * 1.2f, 0);
		CardsOnBoard.Add (card);
		CardsOnBoardCounter++;
		Hands.CardsHeld [MainInfo.CurrentTurn].Remove (card);

		if (CardsOnBoardCounter == 1) 
		{
			MainInfo.CurrentTurn = (MainInfo.CurrentTurn + 1) % 2;
			PlayerSwapper.Swap (MainInfo.CurrentTurn);
		}
		if (CardsOnBoardCounter == 2) 
		{
			MainInfo.Flags.Game = false;
			MainInfo.Flags.SessionResults = true;
			timer = 1f;
		}
		MainInfo.CardsPlayed++;
	}

	public bool TryToPlay (GameObject card)
	{
		if (CardsOnBoardCounter == 0) 
		{
			return true;
		} 
		else 
		{
			if (CardsOnBoard [0].GetComponent<CardScript> ().suit == card.GetComponent<CardScript> ().suit) 
			{
				return true;
			}
			else if (card.GetComponent<CardScript> ().suit == MainInfo.Trump)
			{
				if (!Rules.CheckForSuit (CardsOnBoard [0].GetComponent<CardScript> ().suit, MainInfo.CurrentTurn)) { return true; }
			}
			else
			{
				if (!Rules.CheckForSuit (CardsOnBoard [0].GetComponent<CardScript> ().suit, MainInfo.CurrentTurn) 
					&& !Rules.CheckForTrump (CardsOnBoard [0].GetComponent<CardScript> ().suit, MainInfo.CurrentTurn)) { return true; }
			}
		}
		return false;
	}

}
