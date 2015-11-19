using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {

	private PlayerControl player = null;
	private float distance;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		Delete_Block();
	}

	void Delete_Block()
	{
		distance = player.transform.position.x - gameObject.transform.position.x;

		if (distance > 15f)
			Destroy(gameObject);
	}
}
