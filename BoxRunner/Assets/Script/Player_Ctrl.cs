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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if (PState == PlayerState.JUMP)
				DoubleJump();

			if(PState == PlayerState.RUN)
				Jump();

			
		}
	}

	void Jump()
	{
		PState = PlayerState.JUMP;
		rigidbody.AddForce(new Vector3(0, Jump_Power, 0));
	}

	void DoubleJump()
	{
		PState = PlayerState.DOUBLEJUMP;
		rigidbody.AddForce(new Vector3(0, Jump_Power, 0));
	}

	void Run()
	{
		PState = PlayerState.RUN;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(PState != PlayerState.RUN)
		{
			Run();
		}
	}

	void GetCoin()
	{

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
	}
}
