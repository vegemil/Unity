using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour {

	public bool PlayEnd;
	public float Limit_Time = 60f;
	public int Enemy_Count = 10;

	public Text TimeLabel;
	public Text EnemyLabel;
	public GameObject FinalUI;
	public Text FinalMessage;
	public Text FinalScoreLabel;
	public Text PlayerName;

	float score;

	
	// Use this for initialization
	void Start () {
		EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);
		TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);
		PlayerName.text = PlayerPrefs.GetString("UserName");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayEnd != true)
		{
			if(Limit_Time>0)
			{
				Limit_Time -= Time.deltaTime;
				TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);
			}
			else
			{
				GameOver();
			}
		}
	}

	public void Clear()
	{
		if(PlayEnd != true)
		{
			Time.timeScale = 0;
			PlayEnd = true;
			FinalMessage.text = "Clear!!";

			Player_Ctrl PlayerCtrl = GameObject.Find("Player").GetComponent<Player_Ctrl>();

			score = 12345f + Limit_Time * 123f + PlayerCtrl.hp * 123f;
			FinalScoreLabel.text = string.Format("{0:N0}", score);

			FinalUI.SetActive(true);

			BestCheck();

		}
	}

	public void GameOver()
	{
		if(PlayEnd != true)
		{
			Time.timeScale = 0;
			PlayEnd = true;
			FinalMessage.text = "Fail...";
			score = 1234f + Enemy_Count * 123f;
			FinalScoreLabel.text = string.Format("{0:N0}", score);
			FinalUI.SetActive(true);

			Player_Ctrl PlayerCtrl = GameObject.Find("Player").GetComponent<Player_Ctrl>();
			PlayerCtrl.PState = PlayerState.DEAD;

			BestCheck();
		}
	}

	public void Replay()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("Play");
	}

	public void Quit()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("Title");
	}

	public void EnemyDie()
	{
		Enemy_Count--;
		EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);

		if(Enemy_Count <=0)
		{
			Clear();
		}
	}
	public void BestCheck()
	{
		float BestScore = PlayerPrefs.GetFloat("BestScore");

		if(score>BestScore)
		{
			PlayerPrefs.SetFloat("BestScore", score);
			PlayerPrefs.SetString("BestPlayer", PlayerPrefs.GetString("UserName"));
		}
	}
}
