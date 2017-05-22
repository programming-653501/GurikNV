using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panels : MonoBehaviour 
{
	public MainInfo MainInfo;

	public GameObject Name1;
	public GameObject Name2;
	public GameObject Score1;
	public GameObject Score2;
	public GameObject Bet;

	void Update () 
	{
		if (MainInfo.CurrentTurn == 0) {Name1.GetComponent<Text> ().text = "(Turn)Player1";} 
		else {Name1.GetComponent<Text> ().text = "Player1";}
		if (MainInfo.CurrentTurn == 1) {Name2.GetComponent<Text> ().text = "(Turn)Player2";} 
		else {Name2.GetComponent<Text> ().text = "Player2";}
		Score1.GetComponent<Text> ().text = MainInfo.Scores[0].ToString ();
		Score2.GetComponent<Text> ().text = MainInfo.Scores[1].ToString ();
		Bet.GetComponent<Text> ().text = MainInfo.bet.ToString ();
	}
}
