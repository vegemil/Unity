using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Text jewelText;
	Text swordText;

	int count = 0;
	bool ItHasSword = false;

	// Use this for initialization
	void Start () {
		jewelText = GameObject.Find("Jewel Count Text").GetComponent<Text>();
		swordText = GameObject.Find("Sword Text").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

		if (ItHasSword == true)
		{
			swordText.text = "칼 있음!!";
		}
		else
			swordText.text = "칼 없음!!";
	}

	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.transform.name.Contains("Jewel"))
		{
			count++;
			jewelText.text = count.ToString() + "개";

			Destroy(collision.gameObject);
		}

		else if (collision.gameObject.transform.name.Contains("Sword"))
		{
			ItHasSword = true;
		}

	}


}
