using UnityEngine;
using System.Collections;

public class ColliderCheck : MonoBehaviour {
	public float radius = 5f;
	public float power = 10.0f;

	public AudioClip effect_sound;
	AudioSource audio;

	Rigidbody rigidbody;

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

		PlayerControl.Count += 1;
		if(PlayerControl.Count >= 3)
		{
			if(PlayerControl.Rezentime <=3)
			{
				if (PlayerControl.RezenMaxdistance >= PlayerControl.RezenMindistance)
					PlayerControl.RezenMaxdistance -= 1;
			}
			else
				PlayerControl.Rezentime -= 1;
		}

		Debug.Log("Count : " + PlayerControl.Count);
		Debug.Log("RezenTime : " + PlayerControl.Rezentime);
		Debug.Log("RezenMaxdistance : " + PlayerControl.RezenMaxdistance);
	}

}
