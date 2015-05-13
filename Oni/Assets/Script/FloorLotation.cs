using UnityEngine;
using System.Collections;

public class FloorLotation : MonoBehaviour {


	static float MODEL_NUM = 5;
	static float WIDTH =  10.0f;
	
	public GameObject Player;

	public float total_width;
	public Vector3 floor_Position;


	void Start()
	{
		total_width = WIDTH * MODEL_NUM;

		floor_Position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(floor_Position.z + total_width * 0.2f < Player.transform.position.z)
		{
			floor_Position.z += total_width;
			this.transform.position = floor_Position;
		}
	}
}
