using UnityEngine;
using System.Collections;

public class ColliderCheck : MonoBehaviour {
	public float radius = 5f;
	public float power = 10.0f;

	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.transform.name);
		rigidbody = collision.gameObject.GetComponent<Rigidbody>();

		rigidbody.AddExplosionForce(power, collision.gameObject.transform.position, radius);

	}
}
