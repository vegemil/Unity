using UnityEngine;
using System.Collections;

public class HorseControl : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.z - this.transform.position.z > 5.0f)
		{
			this.gameObject.SetActive(false);
		}
	}

}
