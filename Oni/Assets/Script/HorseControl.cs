using UnityEngine;
using System.Collections;

public class HorseControl : MonoBehaviour {

	public GameObject Player;
	public Rigidbody rigidbody;

    public GameObject HorseMask;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.z - this.transform.position.z > 5.0f)
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.Sleep();


            HorseMask.transform.position = new Vector3(0, 1.35f, 0);
            HorseMask.transform.FindChild("horse_mask").gameObject.transform.position = new Vector3(0f, 1.3f, 0f);
            HorseMask.transform.FindChild("horse_mask").gameObject.transform.rotation = new Quaternion(5f, 0, 0, 0);

			HorseMask.SetActive(false);

            PlayerControl.Count = 0;
            PlayerControl.RezenMaxdistance = 10.0f;
            PlayerControl.Rezentime = 7.0f;

            Debug.Log("Count : " + PlayerControl.Count);
            Debug.Log("RezenTime : " + PlayerControl.Rezentime);
            Debug.Log("RezenMaxdistance : " + PlayerControl.RezenMaxdistance);

		}
	}

}
