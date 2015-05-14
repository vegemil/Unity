using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

	public Animator Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(true)
		{
			if (Input.GetMouseButtonDown(0))
				Player.SetTrigger("Jump");
		}
	}

	
}
