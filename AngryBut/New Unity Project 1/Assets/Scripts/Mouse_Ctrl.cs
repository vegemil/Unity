using UnityEngine;
using System.Collections;

public class Mouse_Ctrl : MonoBehaviour {

	public Transform Target;
	public GameObject Curser;
	public Player_Ctrl PCtrl;

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Curser.transform.position = new Vector3(hit.point.x, 0f, hit.point.z);

			if(Input.GetMouseButtonDown(0) && PCtrl.PState != PlayerState.DEAD)
			{
				Target.position = new Vector3(hit.point.x, 0f, hit.point.z);
				PCtrl.lookDirection = Target.position - PCtrl.gameObject.transform.position;
				PCtrl.StartCoroutine("Shot");
			}
		}
	}
}
