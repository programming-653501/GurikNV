using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRANSFER : MonoBehaviour 
{

	public MainInfo MI;
	public PlayerSwapper PS;
	
	void OnMouseUp () 
	{
		MI.CurrentTurn = (MI.CurrentTurn + 1) % 2;
		PS.Swap (MI.CurrentTurn);		
	}
}
