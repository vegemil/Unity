using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () 
    {
        anim = this.GetComponent<Animator>();
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
