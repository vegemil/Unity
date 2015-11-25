using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    private Vector3 lastPosition;
    private Vector3 delta;

    public float rotateSpeed = 20;
    public float moveSpeed = 10;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public Vector3 target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            transform.LookAt(transform.position);

            transform.RotateAround(target, new Vector3(v * -1f, h * -1f, 0), Time.deltaTime * rotateSpeed);

            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastPosition;

            Debug.Log("delta X : " + delta.x);
            Debug.Log("delta Y : " + delta.y);

            transform.Translate(delta * Time.deltaTime * moveSpeed);

            lastPosition = Input.mousePosition;
        }

    }

//    public void OnMouseDown()
//    {
//        if()

//        mouseDownPosition = Input.mousePosition;
//    }

//    public void OnMouseUp()
//    {
//        mouseUpPosition = Input.mousePosition;
//    }
}
