using UnityEngine;
using System.Collections;

public class ColliderCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.transform.name);
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.transform.name);
	}
}
