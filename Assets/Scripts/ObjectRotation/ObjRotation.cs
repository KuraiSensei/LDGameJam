using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotation : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public GameObject selectedObject;

    void Update()
    {
        if (selectedObject == gameObject)
        {
            // rotate forward when pressing up arrow key or vertical axis is positive
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
            {
                transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            }

            // rotate backward when pressing down arrow key or vertical axis is negative
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
            {
                transform.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
            }

            // rotate to the right when pressing right arrow key or horizontal axis is positive
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }

            // rotate to the left when pressing left arrow key or horizontal axis is negative
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
            {
                transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            }
        }
    }
}

