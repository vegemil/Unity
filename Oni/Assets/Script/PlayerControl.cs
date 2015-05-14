using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float Speed = 1.0f;
	public GameObject[] horses;

	public float Rezentime = 5;

	public float RezenMaxdistance = 10;
	public float RezenMindistance = 5;

	public int Count = 0;

	float time = 0;
	public enum Status
	{
		IDLE,
		ATTACK,
		DEAD
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);

		time += Time.deltaTime;

		if (time >= Rezentime)
		{
			RezenHorse();
			time = 0;
		}
	}

	//말머리 만듬
	void RezenHorse()
	{
		for(int i = 0; i<horses.Length; i++)
		{
			if(horses[i].activeInHierarchy == false)
			{
				horses[i].transform.position = new Vector3(0, 1.3f, this.gameObject.transform.position.z + Random.Range(RezenMindistance, RezenMaxdistance));
				horses[i].SetActive(true);

				break;
			}
		}
	}

	//플레이어로 부터 가장 멀리 있는 말머리를 찾음
	GameObject FindHorse()
	{
		float distance = 0;
		GameObject horse = horses[0];

		for(int i = 0; i<horses.Length; i++)
		{
			if(horses[i].activeInHierarchy == true)
			{
				if(horses[i].transform.position.z - transform.position.z >distance)
				{
					horse = horses[i];
					distance = horses[i].transform.position.z - transform.position.z;
				}
			}
		}

		return horse;
	}


	

}
