using UnityEngine;
using System.Collections;

public class ObjControl : MonoBehaviour
{
    public Renderer rend;
    Ray ray;
    private Vector3 lastPosition;
    private Vector3 delta;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Obj")
            {
                if (Input.GetMouseButtonDown(0))
                {
                }
                else if (Input.GetMouseButton(0))
                {
                    rend.material.color -= Color.magenta * Time.deltaTime;
                }
            }
        }
    }

    public void OnMouseDrag()
    {
    }
}
