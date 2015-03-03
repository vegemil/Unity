using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
	PLAY,
	PAUSE,
	END
};

public class GameManager : MonoBehaviour {

	public GameState GState;

	public Text Text_Meter;
	public Text Text_Gold;

	public GameObject Final_UI;

	public Text Final_Meter;
	public Text Final_Gold;

	public GameObject Pause_UI;

	public float speed;
	public float Meter;
	public int Gold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GState == GameState.PLAY)
		{
			Meter += Time.deltaTime * speed;
			Text_Meter.text = string.Format("{0:N0}m", Meter);
		}

		
	}

	public void GetCoin()
	{
		Gold++;
		Text_Gold.text = string.Format("{0}", Gold);
	}

	public void GameOver()
	{
		Final_Meter.text = Text_Meter.text;
		Final_Gold.text = Text_Gold.text;

		GState = GameState.END;
		Final_UI.SetActive(true);
	}

	public void Replay()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("Play");
	}

	public void MainGo()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("Intro");
	}

	public void Pause()
	{
		GState = GameState.PAUSE;
		Time.timeScale = 0f;
		Pause_UI.SetActive(true);
	}

	public void UnPause()
	{
		GState = GameState.PLAY;
		Time.timeScale = 1f;
		Pause_UI.SetActive(false);
	}
}
