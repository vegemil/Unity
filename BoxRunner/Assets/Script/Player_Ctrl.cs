using UnityEngine;
using System.Collections;

public enum PlayerState
{
	RUN,
	JUMP,
	DOUBLEJUMP,
	DEATH
};

public class Player_Ctrl : MonoBehaviour {

	public PlayerState PState;
	public float Jump_Power = 500f;
	public AudioClip[] Sound;
	public Animator animator;

	public GameObject AnotherSpeaker;
	public GameManager GameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && PState != PlayerState.DEATH)
		{
			if (PState == PlayerState.JUMP)
				DoubleJump();

			if(PState == PlayerState.RUN)
				Jump();
		}

        if(Input.touchCount >0)
        {
            //첫번재 터치의 단계가 지금 화면에 닿은 경우
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (PState == PlayerState.JUMP)
                    DoubleJump();

                if (PState == PlayerState.RUN)
                    Jump();
            }
        }
	}

	void Jump()
	{
		PState = PlayerState.JUMP;
		rigidbody.AddForce(new Vector3(0, Jump_Power, 0));
		AnotherSpeaker.SendMessage("SoundPlay");
		animator.SetTrigger("Jump");
		animator.SetBool("Ground", false);
	}

	void DoubleJump()
	{
		PState = PlayerState.DOUBLEJUMP;
		rigidbody.AddForce(new Vector3(0, Jump_Power, 0));
		AnotherSpeaker.SendMessage("SoundPlay");
		animator.SetTrigger("DoubleJump");
		animator.SetBool("Ground", false);
	}

	void Run()
	{
		PState = PlayerState.RUN;

		animator.SetBool("Ground", true);
	}

	void OnCollisionEnter(Collision collision)
	{
		if(PState != PlayerState.RUN && PState != PlayerState.DEATH)
		{
			Run();
		}
	}

	void GetCoin()
	{
		SoundPlay(0);
        if (GameManager != null)
        {
            GameManager.GetCoin();
        }
	}

	void OnTriggerEnter(Collider other)
	{
		rigidbody.WakeUp();
		if(other.gameObject.name == "Coin")
		{
			Destroy(other.gameObject);
			GetCoin();
		}

		if (other.gameObject.name == "DeathZone" && PState != PlayerState.DEATH)
		{
			GameOver();
		}
	}

	void GameOver()
	{
		PState = PlayerState.DEATH;
		SoundPlay(1);
		GameManager.GameOver();
	}

	void SoundPlay(int num)
	{
		audio.clip = Sound[num];
		audio.Play();
	}
}
