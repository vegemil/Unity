using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	private float power;
	public float POWERPLUS = 100.0f;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			power += POWERPLUS * Time.deltaTime;
		}

		if(Input.GetMouseButtonUp(0))
		{
			rigidBody.AddForce(new Vector3(power, power, 0));
			power = 0;
		}

		if(this.transform.position.y < -5f)
		{
			Application.LoadLevel("gameScene");
		}
	}
}
