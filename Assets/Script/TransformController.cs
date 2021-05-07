using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public Transform target;
    public bool isRotate;
    void Start()
    {
        isRotate=false;
    }
    void FixedUpdate()
    {
        

        if(isRotate){

            transform.Rotate(0.0f, 5f, 0.0f,Space.World);
        }   
    }
}
