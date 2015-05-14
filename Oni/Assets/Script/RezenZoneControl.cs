using UnityEngine;
using System.Collections;

public class RezenZoneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 public void OnTriggerEnter(Collider other)
	{

//         Debug.Log(other.gameObject.name);
		other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		other.gameObject.GetComponent<Rigidbody>().Sleep();

		other.gameObject.transform.parent.gameObject.transform.position = new Vector3(0, 1.35f, 0);
		other.transform.position = new Vector3(0f, 1.3f, 0f);
		other.transform.rotation = new Quaternion(5f, 0, 0, 0);

		other.gameObject.transform.parent.gameObject.SetActive(false);
	}

}
