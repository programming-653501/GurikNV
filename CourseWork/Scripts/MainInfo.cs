using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInfo : MonoBehaviour
{
	public static class Flags
	{
		public static bool Preparations = false;
		public static bool Trade = false;
		public static bool ReserveGiveaway = false;
		public static bool Game = false;
		public static bool SessionResults = false;
		public static bool Results = false;
	}

	public int OnBet = 0;
	public int StartingTurn = 0; //ToSaveLoad
	public int CurrentTurn = 0;
	public int CurrentStartingTurn = 0;

	public int bet = 100;
	public int[] MaxBet = { 120, 120 };
	public int[] Scores = { 0, 0 }; //ToSaveLoad
	public int[] CurrentScores = { 0, 0 };
	public int[] Bolts = { 0, 0 }; //ToSaveLoad

	public bool[] Barrel = { false, false }; //ToSaveLoad
	public int[] Barrels = { 0, 0 }; //ToSaveLoad
	public int[] SessionsOnBarrel = { 0, 0 }; //ToSaveLoad

	public int CardsPlayed = 0;

	public char Trump = ' ';
}
