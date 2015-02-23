using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public int Count;
	public float _time;
	bool End;
    public UnityEngine.UI.Text text_time;
    public GameObject ClearUI;
    public GameObject FailUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(End == false)
		{
			_time += Time.deltaTime;
            text_time.text = _time.ToString();
		}
	}

	void OnTriggerEnter(Collider get)
	{
		if(get.collider.tag == "Box")
		{
			Count += 1;
		}
        if(get.collider.tag =="Player" && End == false)
        {
            End = true;
            FailUI.SetActive(true);
        }

        if (Count >= 16 && End == false)
        {
            End = true;
            ClearUI.SetActive(true);
        }
	}
}
