using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour
{
    public Transform childObject;
    Touch touch;
    float screenWidth = Screen.width;
    float direction = 0.0f;
    void OnEnable()
    {
        transform.rotation = childObject.rotation;
    }
    void Update()
    {

        touch = Input.GetTouch(0);
        if (Input.touchCount == 1)
        {
            if (touch.position.x > (screenWidth / 2))
            {
                direction = 3.0f;
            }
            else
            {
                direction = -3.0f;
            }
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0.0f, direction, 0.0f, Space.Self);
    }
}
