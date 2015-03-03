using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
	public Image Black_screen;
	public float Fade_Time = 2f;
	public float Fade_Max = 1f;
	float _time;
	public bool FadeIn_ing = true;
	public bool FadeOut_ing;

	void Start ()
	{

	}

	void Update ()
	{
		if (FadeIn_ing) {
			_time += Time.deltaTime;
			Black_screen.color = Color.Lerp (new Color (0, 0, 0, Fade_Max), new Color (0, 0, 0, 0), _time / Fade_Time);
		}

		if (FadeOut_ing) {
			_time += Time.deltaTime;
			Black_screen.color = Color.Lerp (new Color (0, 0, 0, 0), new Color (0, 0, 0, Fade_Max), _time / Fade_Time);
		}

		if (_time >= Fade_Time) {
			_time = 0;
			
			FadeOut_ing = false;
			
			if(FadeIn_ing==true){
				Destroy(this.gameObject);	
			}
			
		}
	}

	public void FadeIn ()
	{
		FadeIn_ing = true;
	}

	public void FadeOut ()
	{
		FadeOut_ing = true;
	}
}