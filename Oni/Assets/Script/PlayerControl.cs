using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float Speed = 1.0f;
	public GameObject[] horses;

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

        Debug.Log(time);

		if(time >=7)
		{
			StartCoroutine("RezenHorse");
			time = 0;
		}
	}

	//말머리 만듬
	IEnumerator RezenHorse()
	{
// 		yield return new WaitForSeconds(5);

		for(int i = 0; i<horses.Length; i++)
		{
			if(horses[i].activeInHierarchy == false)
			{
// 				horses[i].transform.position = new Vector3(0, 1.4f,  + FindHorse().transform.position.z + Random.Range(5, 20));
				horses[i].transform.position = new Vector3(0, 1.4f, this.gameObject.transform.position.z + Random.Range(5, 20));
				horses[i].SetActive(true);

				break;
			}
		}

        yield return null;
	}

	//플레이어로 부터 가장 멀리 있는 말머리를 찾음
	private GameObject FindHorse()
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
