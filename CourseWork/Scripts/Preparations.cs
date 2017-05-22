using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preparations : MonoBehaviour
{
	GameObject[] Pack;
	public MainInfo MainInfo;

	public Hands Hands;
	public Rules Rules;

	public GameObject TradePanel;
	public GameObject StagePanel;
	public Text StageName;

	public PlayerSwapper PlayerSwapper;

	void Start() 
	{
		Pack = GameObject.FindGameObjectsWithTag ("card");
	}

	void Update ()
	{
		if (MainInfo.Flags.Preparations) 
		{
			Shuffle ();
			Giveaway ();

			for (int i = 0; i < 2; i++) 
			{ 
				MainInfo.MaxBet [i] = 120;
				if (Rules.CheckForSet ('♥', i))
					MainInfo.MaxBet [i] += 100;
				if (Rules.CheckForSet ('♦', i))
					MainInfo.MaxBet [i] += 80;
				if (Rules.CheckForSet ('♣', i))
					MainInfo.MaxBet [i] += 60;
				if (Rules.CheckForSet ('♠', i))
					MainInfo.MaxBet [i] += 40;
			}

			MainInfo.Flags.Preparations = false;
			MainInfo.Flags.Trade = true;

			MainInfo.bet = 100;
			MainInfo.CurrentTurn = MainInfo.StartingTurn;
			PlayerSwapper.Swap (MainInfo.CurrentTurn);
			TradePanel.SetActive (true);
			StagePanel.SetActive (true);
			StageName.text = "Trade";
		}
	}

	void Swap (ref GameObject a, ref GameObject b) 
	{
		GameObject temp = a;
		a = b;
		b = temp;
	}
		
	void Shuffle ()
	{
		for (int i = 0; i < 100; i++)
		{
			Swap (ref Pack[(int)Mathf.Round(Random.value * (float)23.0)], ref Pack[(int)Mathf.Round(Random.value * (float)23.0)]);

		}
	}

	void Giveaway ()
	{
		for (int i = 0; i < 4; i++) 
		{
			Hands.CardsHeld[2].Add (Pack[i]);
			Pack [i].transform.position = new Vector2 ((float)(28.0 + 1.5 * (float)(i)), (float)-4);
		}
		for (int i = 4; i < 14; i++) 
		{
			Hands.CardsHeld[0].Add (Pack[i]);
			Pack [i].transform.position = new Vector2 ((float)(-8.0 + 1.2 * (float)(i-4)), (float)-4);
			Pack [i].SetActive (false);
		}
		for (int i = 14; i < 24; i++) 
		{
			Hands.CardsHeld[1].Add (Pack[i]);
			Pack [i].transform.position = new Vector2 ((float)(-8.0 + 1.2 * (float)(i-14)), (float)-4);
			Pack [i].SetActive (false);
		}
	}
}
