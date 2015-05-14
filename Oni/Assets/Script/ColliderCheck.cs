using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColliderCheck : MonoBehaviour {
	public float radius = 5f;
	public float power = 10.0f;

	public AudioClip effect_sound;
	AudioSource audio;

	Rigidbody rigidbody;

	public Text comboText;
	public Text countText;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
// 		Debug.Log(collision.gameObject.transform.name);
		rigidbody = collision.gameObject.GetComponent<Rigidbody>();

		audio.PlayOneShot(effect_sound);

		rigidbody.AddExplosionForce(power, collision.gameObject.transform.position, radius);

		PlayerControl.ComboCount += 1;
		PlayerControl.Count += 1;
		if(PlayerControl.ComboCount >= 3)
		{
			if(PlayerControl.Rezentime <=3)
			{
				if (PlayerControl.RezenMaxdistance >= PlayerControl.RezenMindistance)
					PlayerControl.RezenMaxdistance -= 1;
			}
			else
				PlayerControl.Rezentime -= 1;
		}

		if(PlayerControl.ComboCount >=2)
		{
			StartCoroutine("TextEffect");
		}
		
		Debug.Log("Count : " + PlayerControl.ComboCount);
		Debug.Log("RezenTime : " + PlayerControl.Rezentime);
		Debug.Log("RezenMaxdistance : " + PlayerControl.RezenMaxdistance);

		countText.text = PlayerControl.Count.ToString("00");
	}


	IEnumerator TextEffect()
	{
		comboText.text = "콤보" + PlayerControl.ComboCount;
		comboText.gameObject.SetActive(true);
		yield return new WaitForSeconds(1);
		comboText.gameObject.SetActive(false);
	}

}
