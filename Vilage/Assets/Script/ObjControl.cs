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
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (GameManager.Instance.IsCameraMove == true)
            return;

        if (GameManager.Instance.IsObjMove == false)
        {
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.name);

                if (hit.transform.parent.tag == "Obj")
                {
                    GameManager.Instance.IsObjMove = true;
                }
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
            else if (Input.GetMouseButton(0))
            {
                rend.material.color = Color.magenta;
                
                if(Physics.Raycast(ray, out hit, 100, 8))
                {
                    Debug.Log(hit.transform.gameObject.name);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rend.material.color = defaultColor;
                GameManager.Instance.IsObjMove = false;
            }


        }
    }

    public void OnMouseDrag()
    {
    }
}
