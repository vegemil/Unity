using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    private Vector3 lastPosition;
    private Vector3 delta;

    public float rotateSpeed = 20;
    public float moveSpeed = 10;
    public float zoomSpeed = 10;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public float MaxCameraSize = 15;
    public float MinCameraSize = 5;

    public Vector3 target;

    private RaycastHit hit;
    private Ray ray;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.layer == 5)
                    return;
                else if (hit.transform.gameObject.tag == "Obj")
                    return;
                else
                {
                    RightMouseButtonClick();
                    LeftMouseButtonClick();
                    WheelMouseScroll();
                }
            }
    }

    void RightMouseButtonClick()
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

            transform.RotateAround(target, new Vector3(v, h, 0), Time.deltaTime * rotateSpeed);

            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
        }

    }

    void LeftMouseButtonClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastPosition;

            //Debug.Log("delta X : " + delta.x);
            //Debug.Log("delta Y : " + delta.y);

            transform.Translate(delta * Time.deltaTime * moveSpeed);

            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
        }
    }

    void WheelMouseScroll()
    {
        
        if ((Camera.main.orthographicSize + (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed)) > MaxCameraSize)
        {
            Camera.main.orthographicSize = MaxCameraSize;
        }
        else if((Camera.main.orthographicSize + (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed)) < MinCameraSize)
        {
            Camera.main.orthographicSize = MinCameraSize;
        }
        else
        {
            Camera.main.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
    }
}
