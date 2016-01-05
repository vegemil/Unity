using UnityEngine;
using System.Collections;

public class HeadBilboard : MonoBehaviour
{
    public Transform Body;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Body.position.normalized;
        Vector3 target = Camera.main.transform.position.normalized;

        forward.y = 0;
        target.y = 0;

        float angle = Vector3.Angle(forward, target);
        //Debug.Log(angle);

        if (angle > 70)
            return;

        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(Vector3.right, -90f);
    }

}
