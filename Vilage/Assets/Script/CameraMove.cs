using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    private Vector3 lastPosition;
    private Vector3 delta;

    public float rotateSpeed = 20;

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
            delta = Input.mousePosition - lastPosition;

            Debug.Log("delta X : " + delta.x);
            Debug.Log("delta Y : " + delta.y);

            //transform.RotateAround(lastPosition, delta, Time.deltaTime * rotateSpeed);
            //transform.Rotate(delta * 0.01f);

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100f))
            {
                GameObject parent = hit.transform.parent.gameObject;

                while (parent.transform.parent.gameObject.tag != "Ground")
                {
                    parent = parent.transform.parent.gameObject;
                }

                target = parent.transform.parent.position; 
            }


            transform.LookAt(target);

            //-1f를 곱해 마우스가 움직이는 방향대로 움직이도록 함
            transform.RotateAround(target, new Vector3(v * -1f, h * -1f, 0), Time.deltaTime * rotateSpeed);

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
