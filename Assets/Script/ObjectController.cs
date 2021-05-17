using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public enum objectState
    {

        fire,
        rotate,

    }
    public Rigidbody rigidbodyObject;
    Vector3 clickPosition = -Vector3.one;
    RaycastHit hit;
    Ray ray;
    public GameObject parentObject;
    public float moveSpeed;
    public bool move;

    void Awake()
    {

        move = true;
        moveSpeed = 0.1f;
        parentObject.SetActive(false);
    }
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            parentObject.transform.rotation = Quaternion.Euler(transform.eulerAngles);
            move = false;
            clickPosition = -Vector3.one;


            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {

                clickPosition = hit.point;
                if (hit.transform != null)
                {

                    parentObject.SetActive(true);
                    parentObject.transform.position = clickPosition;
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {

            transform.SetParent(parentObject.transform);
            // transform.rotation =Quaternion.Euler(parentObject.transform.eulerAngles);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            transform.rotation = Quaternion.Euler(parentObject.transform.eulerAngles);
            transform.SetParent(null);
            parentObject.SetActive(false);
            move = true;
        }
    }
    void FixedUpdate()
    {
        if (move)
        {
            rigidbodyObject.AddForce(transform.forward * moveSpeed);
        }
        else
        {

            rigidbodyObject.velocity = Vector3.zero;
        }
    }
}

