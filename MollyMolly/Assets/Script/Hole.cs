using UnityEngine;
using System.Collections;

public enum MoleState
{
	NONE,
	OPEN,
	IDLE,
	CLOSE,
	CATCH
};

public class Hole : MonoBehaviour
{
	//두더지 상태
	public MoleState MState = MoleState.CLOSE;

	//두더지 상태별 텍스쳐
	public Texture[] Good_Open_Images;
	public Texture[] Good_Idle_Images;
	public Texture[] Good_Close_Images;
	public Texture[] Good_Catch_Images;

	public Texture[] Bad_Open_Images;
	public Texture[] Bad_Idle_Images;
	public Texture[] Bad_Close_Images;
	public Texture[] Bad_Catch_Images;


	//애니메이션 속도관리 
	public float Ani_Speed;
	public float _now_ani_time;

	//애니메이션 카운트
	int Ani_Count;

	//애니메이션 사운드
	public AudioClip Open_Sound;
	public AudioClip Catch_Sound;

	public bool isGoodMole;
	public int PerGood = 15;

	public float wait_Time = 4.5f;

	public GameManager GManager;

	// Update is called once per frame
	void Update()
	{
		if (_now_ani_time >= Ani_Speed)
		{
			if (MState == MoleState.OPEN)
			{
				Open_Ing();
			}

			if (MState == MoleState.IDLE)
			{
				Idle_Ing();
			}
			if (MState == MoleState.CATCH)
			{
				Catch_Ing();
			}
			if (MState == MoleState.CLOSE)
			{
				Close_Ing();
			}
			_now_ani_time = 0;
		}

		else
		{
			_now_ani_time += Time.deltaTime;
		}
	}

	public void Open_On()
	{
		MState = MoleState.OPEN;
		Ani_Count = 0;

		audio.clip = Open_Sound;
		audio.Play();


		//perGood의 확률만큼 랜덤생성하게 만들어주는 코드
		int a = Random.Range(0, 100);

		if(a<= PerGood)
		{
			isGoodMole = true;
		}
		else
		{
			isGoodMole = false;
		}

		if (GManager.GState == GameState.READY)
		{
			GManager.Go();
		}
	}

	public void Open_Ing()
	{
		Texture[] Images;
		if (isGoodMole == false)
			Images = Good_Open_Images;
		else
			Images = Bad_Open_Images;

		renderer.material.mainTexture = Images[Ani_Count];
		Ani_Count += 1;

		//Open 애니메이션이 끝나는 순간
		if (Ani_Count >= Images.Length)
		{
			Idle_On();
		}
	}

	public void Idle_On()
	{
		MState = MoleState.IDLE;
		Ani_Count = 0;
	}

	public void Idle_Ing()
	{
		Texture[] Images;
		if (isGoodMole == false)
			Images = Good_Idle_Images;
		else
			Images = Bad_Idle_Images;

		renderer.material.mainTexture = Images[Ani_Count];
		Ani_Count += 1;

		//Idle 애니메이션이 끝나는 순간
		if (Ani_Count >= Images.Length)
		{
			Close_On();
		}
	}

	public void Close_On()
	{
		MState = MoleState.CLOSE;
		Ani_Count = 0;
	}

	public void Close_Ing()
	{
		Texture[] Images;
		if (isGoodMole == false)
			Images = Good_Close_Images;
		else
			Images = Bad_Close_Images;
		

		renderer.material.mainTexture = Images[Ani_Count];
		Ani_Count += 1;

		//Close 애니메이션이 끝나는 순간
		if (Ani_Count >= Images.Length)
		{
			StartCoroutine("Wait");
		}
	}
	public void Catch_On()
	{
		MState = MoleState.CATCH;
		Ani_Count = 0;

		audio.clip = Catch_Sound;
		audio.Play();

		if (isGoodMole == false)
		{
			GManager.Count_Bad++;
		}
		else
			GManager.Count_Good++;
	}

	public void Catch_Ing()
	{
		Texture[] Images;
		if (isGoodMole == false)
			Images = Good_Catch_Images;
		else
			Images = Bad_Catch_Images;

		renderer.material.mainTexture = Images[Ani_Count];
		Ani_Count += 1;

		//Catch 애니메이션이 끝나는 순간
		if (Ani_Count >= Images.Length)
		{
			StartCoroutine("Wait");
		}
	}


	public IEnumerator Wait()
	{
		MState = MoleState.NONE;
		Ani_Count = 0;

	   

		if(GManager.LimitTime <= 5.0f )
		{
			wait_Time = 2;
		}


		float time = Random.Range(0.5f, wait_Time);

		print(time);
		yield return new WaitForSeconds(time);
		Open_On();
	}

	public void OnMouseDown()
	{
		if (MState == MoleState.IDLE || MState == MoleState.OPEN)
		{
			if (isGoodMole == true)
				Handheld.Vibrate();
			Catch_On();
		}
	}
}
