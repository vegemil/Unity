using UnityEngine;
using System.Collections;

public class ObjControl : MonoBehaviour
{
    public Renderer rend;
    Ray ray;
    private Vector3 lastPosition;
    private Vector3 delta;
    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        defaultColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsCameraMove == false)
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.name);

                if (hit.transform.parent.tag == "Obj")
                {
                    GameManager.Instance.IsObjMove = true;

                    if (Input.GetMouseButtonDown(0))
                    {
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        rend.material.color = Color.magenta;

                        if (Physics.Raycast(ray, out hit, 500, 8))
                        {
                            Debug.Log(hit.transform.gameObject.name);
                            Debug.Log(hit.distance);
                        }
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        rend.material.color = defaultColor;
                        GameManager.Instance.IsObjMove = false;
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            rend.material.color = defaultColor;
            GameManager.Instance.IsObjMove = false;
        }
    }

    public void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
    }
}
