using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public enum objectState
    {

        fire,
        circular,

    }
    public Rigidbody rigidbodyObject;
    public GameObject cube;
    public GameObject cubeChild;
    Vector3 clickPosition = -Vector3.one;
    RaycastHit hit;
    Ray ray;
    public const float speed = 0.2f;

    public bool asd = false;
    void Update()
    {

        if (asd)
        {

            rigidbodyObject.AddForce(cubeChild.transform.forward * 0.02f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            asd = false;
            cube.GetComponent<TransformController>().isRotate = true;

            clickPosition = -Vector3.one;


            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;

                if (hit.transform.tag == "terrain")
                {
                    cube.transform.position = clickPosition;
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {

            transform.position = Vector3.MoveTowards(transform.position, cubeChild.transform.position, speed);
        }
        if (Input.GetKey(KeyCode.U))
        {

            rigidbodyObject.velocity = Vector3.zero;
        }

    }
    void FixedUpdate()
    {

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rigidbodyObject.velocity = Vector3.one;
            cube.GetComponent<TransformController>().isRotate = false;
            asd = true;
        }
    }
}

