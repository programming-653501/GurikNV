using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

	public MainInfo MainInfo;
	public Hands Hands;
	public GameSession GameSession;

	public int value;
	public char suit;
	public bool isPlayed = false;

	public GameObject card;

	public static int CardsGiven = 0;

	void OnMouseUp () 
	{
		if (MainInfo.Flags.ReserveGiveaway && CardsGiven < 2) 
		{
			Hands.CardsHeld [(MainInfo.CurrentTurn + 1) % 2].Add (card);
			Hands.CardsHeld [MainInfo.CurrentTurn].Remove (card);
			card.transform.position = new Vector2 ((float)(4f + 1.2f * (CardsGiven)), -4f);
			card.SetActive (false);
			CardsGiven++;
		} 
		else if (MainInfo.Flags.Game)
		{
			if (GameSession.TryToPlay(card)) GameSession.PlayCard (card);
		}
	}

	void OnMouseEnter ()
	{
		if (MainInfo.Flags.ReserveGiveaway) card.transform.position = new Vector2 (card.transform.position.x, card.transform.position.y + 0.1f);
		if (MainInfo.Flags.Game) 
		{
			if (!GameSession.TryToPlay (card))
				return;
			if (!isPlayed) 
				card.transform.position = new Vector2 (card.transform.position.x, card.transform.position.y + 0.1f);
		}
	}

	void OnMouseExit ()
	{
		if (MainInfo.Flags.ReserveGiveaway) card.transform.position = new Vector2 (card.transform.position.x, card.transform.position.y - 0.1f);
		if (MainInfo.Flags.Game) 
		{
			if (!GameSession.TryToPlay (card))
				return;
			if (!isPlayed) 
				card.transform.position = new Vector2 (card.transform.position.x, card.transform.position.y - 0.1f);
		}
	}
}
