using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour 
{
	public MainInfo MainInfo;

	public void Save()
	{
		string ToSave = MainInfo.StartingTurn.ToString() + "~" + MainInfo.Scores[0].ToString() + "~" + MainInfo.Scores[1].ToString() + "~" +
						MainInfo.Bolts[0].ToString() + "~" + MainInfo.Bolts[1].ToString() + "~" + MainInfo.Barrel[0].ToString() + "~" +
						MainInfo.Barrel[1].ToString() + "~" + MainInfo.Barrels[0].ToString() + "~" + MainInfo.Barrels[1].ToString() + "~" +
						MainInfo.SessionsOnBarrel[0].ToString() + "~" + MainInfo.SessionsOnBarrel[1].ToString();

		File.WriteAllText (@"1000Save.gsf", ToSave);
	}
}
