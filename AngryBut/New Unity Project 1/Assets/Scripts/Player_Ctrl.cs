using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PlayerState
{
	IDLE,
	WALK,
	RUN,
	ATTACK,
	DEAD
}

public class Player_Ctrl : MonoBehaviour {

	public PlayerState PState;

	public Vector3 lookDirection;
	public float Speed = 0f;
	public float WalkSpeed = 6f;
	public float RunSpeed = 12f;

	Animation animation;
	public AnimationClip Idle_Ani;
	public AnimationClip Walk_Ani;
	public AnimationClip Run_Ani;

	public GameObject Bullet;
	public Transform ShotPoint;
	public GameObject ShotFx;
	public AudioClip ShotSound;

	AudioSource audio;
	Collider collider;

	public Scrollbar ProgressBar;
	public float Max_hp = 100;
	public float hp = 100;

	void KeyBoardInput()
	{
		float xx = Input.GetAxisRaw("Vertical");
		float zz = Input.GetAxisRaw("Horizontal");

		if (PState!= PlayerState.ATTACK)
		{
			if(Input.GetKey(KeyCode.LeftArrow) || 
				Input.GetKey(KeyCode.RightArrow) ||
				Input.GetKey(KeyCode.UpArrow) ||
				Input.GetKey(KeyCode.DownArrow))
			{
				lookDirection = xx * Vector3.forward + zz * Vector3.right;
				Speed = WalkSpeed;
				PState = PlayerState.WALK;
	
				if(Input.GetKey(KeyCode.LeftShift) ||
					Input.GetKey(KeyCode.RightShift))
				{
					Speed = RunSpeed;
					PState = PlayerState.RUN;
				}
			}
	
			if(xx == 0 && zz == 0 && PState!= PlayerState.IDLE)
			{
				PState = PlayerState.IDLE;
				Speed = 0f;
			}
		}

		if(Input.GetKeyDown(KeyCode.Space) && PState != PlayerState.DEAD)
		{
			StartCoroutine("Shot");
		}
	}

	void LookUpdate()
	{
		Quaternion R = Quaternion.LookRotation(lookDirection);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);

		transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

	void AnimationUpdate()
	{
		if(PState == PlayerState.IDLE)
		{
			animation.CrossFade(Idle_Ani.name, 0.2f);
		}
		else if(PState == PlayerState.WALK)
		{
			animation.CrossFade(Walk_Ani.name, 0.2f);
		}
		else if(PState == PlayerState.RUN)
		{
			animation.CrossFade(Run_Ani.name, 0.2f);
		}
		else if(PState == PlayerState.ATTACK)
		{
			animation.CrossFade(Idle_Ani.name, 0.2f);
		}
		else if(PState == PlayerState.DEAD)
		{
			animation.CrossFade(Idle_Ani.name, 0.2f);
		}

	}

	public IEnumerator Shot()
	{
		GameObject bullet = Instantiate(Bullet, ShotPoint.position, Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
		Collider bullet_Collider = bullet.GetComponent<Collider>();

		Physics.IgnoreCollision(bullet_Collider,collider);

		audio.clip = ShotSound;
		audio.Play();

		ShotFx.SetActive(true);

		PState = PlayerState.ATTACK;
		Speed = 0f;

		yield return new WaitForSeconds(0.15f);
		ShotFx.SetActive(false);

		yield return new WaitForSeconds(0.15f);
		PState = PlayerState.IDLE;
	}

	public void Hurt(float Damage)
	{
		if(hp>0)
		{
			hp -= Damage;
			ProgressBar.size = hp / Max_hp;
		}

		if(hp <= 0)
		{
			Speed = 0f;
			PState = PlayerState.DEAD;

			PlayManager manager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
			manager.GameOver();
		}
	}

	// Use this for initialization
	void Start () {
		animation = this.GetComponent<Animation>();
		audio = this.GetComponent<AudioSource>();
		collider = this.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PState != PlayerState.DEAD)
		{
			KeyBoardInput();
			LookUpdate();
		}

		AnimationUpdate();
	}
}
