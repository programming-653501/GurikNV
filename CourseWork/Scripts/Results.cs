using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour 
{
	public MainInfo MainInfo;
	public Saver Saver;
	public Winning Winning;

	void Update () 
	{
		if (MainInfo.Flags.Results) 
		{
			MainInfo.StartingTurn = (MainInfo.StartingTurn + 1) % 2;
			for (int i = 0; i < 2; i++) 
			{
				MainInfo.CurrentScores [i] = (int)(Mathf.Round(MainInfo.CurrentScores [i] / 5f)) * 5;
			}

// ЗОНА НЕОБЪЯСНИМОЙ МАГИИ. НЕ ТРОГАТЬ, ОНО И ТАК РАБОТАЕТ

			if (MainInfo.CurrentScores [MainInfo.OnBet] < MainInfo.bet) 
			{
				if (MainInfo.Barrel [MainInfo.OnBet]) 
				{
					MainInfo.Barrel [MainInfo.OnBet] = false;
					if (MainInfo.Barrels [MainInfo.OnBet] == 3) 
					{
						MainInfo.SessionsOnBarrel [MainInfo.OnBet] = 0;
						MainInfo.Barrels [MainInfo.OnBet] = 0;
						MainInfo.Scores [MainInfo.OnBet] = MainInfo.bet;
					}
				}
				MainInfo.Scores [MainInfo.OnBet] -= MainInfo.bet;
			} 
			else 
			{
				if (MainInfo.Barrel [MainInfo.OnBet]) 
				{
					MainInfo.Flags.Results = false;
					Winning.Win (MainInfo.OnBet);
					return;
				} 
				else 
				{
					MainInfo.Scores [MainInfo.OnBet] += MainInfo.bet;
					if (MainInfo.Scores [MainInfo.OnBet] >= 900) 
					{
						MainInfo.Scores [MainInfo.OnBet] = 900;
						MainInfo.Barrel [MainInfo.OnBet] = true;
						MainInfo.Barrels [MainInfo.OnBet]++;
					}
				}
			}
			if (MainInfo.CurrentScores [(MainInfo.OnBet + 1) % 2] == 0) 
			{
				MainInfo.Bolts [(MainInfo.OnBet + 1) % 2]++;
				if (MainInfo.Bolts [(MainInfo.OnBet + 1) % 2] == 3) 
				{
					MainInfo.Bolts [(MainInfo.OnBet + 1) % 2] = 0;
					MainInfo.Scores [(MainInfo.OnBet + 1) % 2] -= 100;
					if (MainInfo.Barrel [(MainInfo.OnBet + 1) % 2]) 
					{
						MainInfo.Barrel [(MainInfo.OnBet + 1) % 2] = false;
						if (MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] == 3) 
						{
							MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Scores [(MainInfo.OnBet + 1) % 2] = 0;
						}
					}
				}
				else
				if (MainInfo.Barrel [(MainInfo.OnBet + 1) % 2]) 
				{
					MainInfo.SessionsOnBarrel[(MainInfo.OnBet + 1) % 2]++;
					if (MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2] == 3) 
					{
						MainInfo.Scores [(MainInfo.OnBet + 1) % 2] -= 100;
						MainInfo.Barrel [(MainInfo.OnBet + 1) % 2] = false;
						if (MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] == 3) 
						{
							MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Scores [(MainInfo.OnBet + 1) % 2] = 0;
						}
					}
				}
			}
			else
			{
				if (MainInfo.Barrel [(MainInfo.OnBet + 1) % 2]) 
				{
					MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2]++;
					if (MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2] == 3) 
					{
						MainInfo.Scores [(MainInfo.OnBet + 1) % 2] -= 100;
						MainInfo.Barrel [(MainInfo.OnBet + 1) % 2] = false;
						if (MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] == 3) 
						{
							MainInfo.SessionsOnBarrel [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Barrels [(MainInfo.OnBet + 1) % 2] = 0;
							MainInfo.Scores [(MainInfo.OnBet + 1) % 2] = 0;
						}
					}
				} else 
				{
					MainInfo.Scores [(MainInfo.OnBet + 1) % 2] += MainInfo.CurrentScores[(MainInfo.OnBet + 1) % 2];
					if (MainInfo.Scores [(MainInfo.OnBet + 1) % 2] >= 900) 
					{
						MainInfo.Scores [(MainInfo.OnBet + 1) % 2] = 900;
						MainInfo.Barrel [(MainInfo.OnBet + 1) % 2] = true;
						MainInfo.Barrels [(MainInfo.OnBet + 1) % 2]++;
					}
				}
			}

// КОНЕЦ ЗОНЫ НЕОБЪЯСНИМОЙ МАГИИ

			MainInfo.CardsPlayed = 0;
			MainInfo.Flags.Results = false;
			MainInfo.Flags.Preparations = true;
			Saver.Save();
		}
	}
}
