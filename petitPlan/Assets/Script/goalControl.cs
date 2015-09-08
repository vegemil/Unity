using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goalControl : MonoBehaviour {

    private bool is_collided = false;
    public Text text;

    public float GOAL_MIN = 5.0f;
    public float GOAL_MAX = 10.0f;

	// Use this for initialization
	void Start () {

        float rnd = Random.Range(GOAL_MIN, GOAL_MAX);

        this.transform.position = new Vector3(rnd, -1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(is_collided == true)
        {
            text.gameObject.SetActive(true);
        }
	}

    public void OnCollisionStay(Collision collision)
    {
        is_collided = true;
    }


}
