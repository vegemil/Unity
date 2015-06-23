using UnityEngine;
using System.Collections;


public class Ghost : MonoBehaviour {

    public GameObject Target;
    public float distance;

    char[,] mapdata;
    int height;
    int width;

    public GameObject Map;

    Vector3 startPosition;
    Vector3 endPosition = Vector3.zero;
    Vector3 dir = Vector3.zero;

    Hashtable hash = new Hashtable();

    public float speed = 1.0F;
    public float grid = 1.0f;
    public float rotationSpeed = 100.0F;

    Animator animator;

    float time = 0;
    
    // Use this for initialization
	void Start () {
        Target = GameObject.Find("SD_unitychan_humanoid(Clone)");
        Map = GameObject.Find("Map");

        height = Map.GetComponent<Map>().height;
        width = Map.GetComponent<Map>().width;

        mapdata = new char[height, width];
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
        if(mapdata[0,0] == '\0' && Map.GetComponent<Map>().IsMapSetting == true)
            mapdata = Map.GetComponent<Map>().mapdata;

//         distance = Vector3.Distance(Target.transform.position, this.gameObject.transform.position);
        if (mapdata[0, 0] != '\0' && time >= 2.0f)
        {
            Idle();
            time = 0;
        }
	}
    
    void Chase()
    {

    }

    void Idle()
    {
        int index = Random.Range(0, 4);
        Move(index);
        
    }

    bool IsMovingOk(Vector3 position)
    {
        

        if (mapdata[height - Mathf.CeilToInt(position.z) - 1, Mathf.CeilToInt(position.x)] == '*')
        {
            time = 0;
            return false;
        }
        else
        {
            Debug.Log(height - Mathf.CeilToInt(position.z) - 1 + ", " + Mathf.CeilToInt(position.x));
            Debug.Log(position);
            Debug.Log(startPosition);
            return true;
        }
    }

    void Move(int index)
    {
        startPosition = transform.position;

        switch (index)
        {
            case 0:         //왼쪽
                hash.Clear();
                endPosition = startPosition + transform.right * grid * -1;

                if (IsMovingOk(endPosition) == false)
                    break;

                dir = endPosition - startPosition;
                dir.y = 0.0f;
                dir.Normalize();

                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                                     Quaternion.LookRotation(dir),
                                                                      rotationSpeed);


                hash.Clear();
                hash.Add("position", endPosition);
                hash.Add("speed", speed);
                hash.Add("easetype", iTween.EaseType.linear);
                iTween.MoveTo(gameObject, hash);

                animator.SetTrigger("Move");
                break;

            case 1:     //오른쪽

                hash.Clear();
                endPosition = startPosition + transform.right * grid;

                if (IsMovingOk(endPosition) == false)
                    break;

                dir = endPosition - startPosition;
                dir.y = 0.0f;
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                                     Quaternion.LookRotation(dir),
                                                                      rotationSpeed);

                hash.Add("position", endPosition);
                hash.Add("speed", speed);
                hash.Add("easetype", iTween.EaseType.linear);
                iTween.MoveTo(gameObject, hash);

                animator.SetTrigger("Move");
                break;


            case 2: //앞

                hash.Clear();

                endPosition = startPosition + transform.forward * grid;

                if (IsMovingOk(endPosition) == false)
                    break;

                hash.Add("position", endPosition);
                hash.Add("speed", speed);
                hash.Add("easetype", iTween.EaseType.linear);
                iTween.MoveTo(gameObject, hash);

                animator.SetTrigger("Move");
                break;

            case 3: //뒤

                hash.Clear();
                endPosition = startPosition + transform.forward * grid * -1;

                if (IsMovingOk(endPosition) == false)
                    break;

                dir = endPosition - startPosition;
                dir.y = 0.0f;
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                                     Quaternion.LookRotation(dir),
                                                                      rotationSpeed);

                hash.Add("position", endPosition);
                hash.Add("speed", speed);
                hash.Add("easetype", iTween.EaseType.linear);
                iTween.MoveTo(gameObject, hash);

                animator.SetTrigger("Move");
                break;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        transform.rotation = new Quaternion(Mathf.Round(transform.rotation.x), Mathf.Round(transform.rotation.y), Mathf.Round(transform.rotation.z), Mathf.Round(transform.rotation.w));

    }

}
