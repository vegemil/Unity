using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    READY,
    PLAY,
    END
};

public class GameManager : MonoBehaviour {
    
    public GameState GState;

    public Hole[] Holes;
    public float LimitTime;
    public Text Timetext;
    public int Count_Bad;
    public int Count_Good;

    public GameObject FinishGUI;
    public Text Final_Count_Bad;
    public Text Final_Count_Good;
    public Text Final_Score;

    public AudioClip ReadySound;
    public AudioClip GoSound;
    public AudioClip FinishSound;

	// Use this for initialization
	void Start () {
        audio.clip = ReadySound;
        audio.Play();
	}
	
    public void Go()
    {
        GState = GameState.PLAY;
        audio.clip = GoSound;
        audio.Play();
    }

	// Update is called once per frame
	void Update () {
	    if(GState == GameState.PLAY)
        {
            LimitTime -= Time.deltaTime;

            if(LimitTime<= 0)
            {
                LimitTime = 0;

                End();
            }
        }
        Timetext.text = string.Format("{0:N2}", LimitTime);
        print(Timetext.text);
	}

    void End()
    {
        GState = GameState.END;
        Final_Count_Bad.text = Count_Bad.ToString();
        Final_Count_Good.text = Count_Good.ToString();
        Final_Score.text = (Count_Bad * 100 - Count_Good * 1000).ToString();
        FinishGUI.SetActive(true);
        audio.clip = FinishSound;
        audio.Play();
    }
}
