using UnityEngine;
using System.Collections;

public class HeadBilboard : MonoBehaviour
{

    Vector3 LookPos;

    public Transform target;
    public Transform frontVector;

    public Animator animator;

    // Use this for initialization
    void Start()
    {
        LookPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 relativePos = Camera.main.transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = rotation;

        //LookPos.x = Camera.main.transform.position.x;
        //LookPos.y = Camera.main.transform.position.y;
        //LookPos.z = Camera.main.transform.position.z;

        //LookPos.y += 100;

        //transform.LookAt(LookPos, Vector3.up);
        //transform.rotation = new Quaternion(transform.rotation.x * 1.5f, transform.rotation.y, transform.rotation.z, transform.rotation.w);


        //var lookPos = target.position - transform.position;
        //lookPos.x = 0;
        //var rotation = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10);

        //Vector3 targetPostition = new Vector3(target.position.x,
        //                               this.transform.position.y,
        //                               target.position.z);
        //this.transform.LookAt(targetPostition);

        //Vector3 worldLookDirection = target.position - transform.position;
        //Vector3 localLookDirection = transform.InverseTransformDirection(worldLookDirection);
        //localLookDirection.y = 0;
        //transform.up = transform.rotation * localLookDirection;

        //transform.up = transform.forward;
        transform.LookAt(target);

        //transform.LookAt(target, Vector3.down);
        //transform.rotation = Quaternion.Euler(Vector3.left);

        //transform.LookAt(transform.position + target.transform.rotation * -Vector3.forward,
        //                     target.transform.rotation * Vector3.up);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position), 10 );
    }

    //public void OnAnimatorIK(int layerIndex)
    //{
    //    animator.SetLookAtWeight(1);
    //}
}
