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
			Debug.Log("rezen");
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
// 				horses[i].transform.FindChild("horse_mask").gameObject.transform.position = new Vector3(0, -0.02052951f, 0.005240204f);

				horses[i].transform.position = new Vector3(0,1.35f, this.gameObject.transform.position.z + Random.Range(RezenMindistance, RezenMaxdistance));
                horses[i].gameObject.transform.FindChild("horse_mask").gameObject.transform.rotation = new Quaternion(0, 1, 0, 0);

				horses[i].gameObject.transform.FindChild("horse_mask").gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				horses[i].gameObject.transform.FindChild("horse_mask").gameObject.GetComponent<Rigidbody>().WakeUp();

				Debug.Log("1-1." + horses[i].transform.position);
                Debug.Log("1-2." + horses[i].transform.rotation);
				Debug.Log("2-1." + horses[i].gameObject.transform.FindChild("horse_mask").gameObject.transform.position);
                Debug.Log("2-2" + horses[i].gameObject.transform.FindChild("horse_mask").gameObject.transform.rotation);


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
