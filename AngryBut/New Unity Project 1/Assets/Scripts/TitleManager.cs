using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

	public Text NameLabel;
	public GameObject BestData;
	public Text BestUserDataLabel;
		 

	public void GoPlay()
	{
		if(NameLabel.text == "")
		{
			return;
		}

		PlayerPrefs.SetString("UserName", NameLabel.text);
		Application.LoadLevel("Play");
	}

	public void BestScore()
	{
		BestUserDataLabel.text = string.Format("{0} : {1:N0}", PlayerPrefs.GetString("BestPlayer"), PlayerPrefs.GetFloat("BestScore"));
		if(BestUserDataLabel.text != ":0")
		{
			BestData.SetActive(true);
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}
