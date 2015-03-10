using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum EnemyState
{
	IDlE,
	MOVE,
	ATTACK,
	HURT,
	DIE
}

public class Enemy : MonoBehaviour {

	public EnemyState EState;

	public Animator anim;

	float Speed;

	public float MoveSpeed;
	public float AttakSpeed;

	public float FindRange = 10f;
	public float Damage = 20f;
	public Transform Player;

	public Transform FX_Point;
	public GameObject Hit_FX;
	public AudioClip Hit_Sound;
	public AudioClip Death_Sound;

	public GameObject UI_Pivot;
	public Scrollbar LifeBar;
	public float MAX_hp = 100;
	public float hp = 100;

	AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		audio = this.GetComponent<AudioSource>();
	}
	
	void DistanceCheck()
	{
		if (Vector3.Distance(Player.position, transform.position) >= FindRange)
		{
			EState = EnemyState.IDlE;
			anim.SetBool("Run", false);
			Speed = 0;
		}

		else
		{
			EState = EnemyState.MOVE;
			anim.SetBool("Run", true);
			Speed = MoveSpeed;
		}
	}
	void MoveUpdate()
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(Player.position.x, this.transform.position.y, Player.position.z) - transform.position);
		transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

	void AttackRangeCheck()
	{
		if (Vector3.Distance(Player.position, transform.position) <1.5f && EState != EnemyState.ATTACK)
		{
			Speed = 0;
			EState = EnemyState.ATTACK;
			anim.SetTrigger("Attack");
		}
	}
	public void Attack_On()
	{
		Player.GetComponent<Player_Ctrl>().Hurt(Damage); 
	}


	public void Hurt(float Damage)
	{
		if(hp >0)
		{
			EState = EnemyState.HURT;
			Speed = 0;
			anim.SetTrigger("Hurt");

			GameObject FX = Instantiate(Hit_FX, FX_Point.position, Quaternion.LookRotation(FX_Point.forward)) as GameObject;

			hp -= Damage;
			LifeBar.size = hp / MAX_hp;

			audio.clip = Hit_Sound;
			audio.Play();
			
			if(hp<=0)
			{
				Death();
			}

		}
	}

	public void Death()
	{
		EState = EnemyState.DIE;
		anim.SetTrigger("Die");
		Speed = 0;

		UI_Pivot.SetActive(false);
		audio.clip = Death_Sound;
		audio.Play();

		PlayManager manager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
		manager.EnemyDie();
	}


	// Update is called once per frame
	void Update () {
	
		if(EState == EnemyState.IDlE)
		{
			DistanceCheck();
		}
		else if(EState == EnemyState.MOVE)
		{
			MoveUpdate();
			AttackRangeCheck();
		}
	}
}
