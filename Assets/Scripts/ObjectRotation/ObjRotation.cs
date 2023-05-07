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
            // rotate forward on W key press
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            }

            // rotate backward on S key press
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(-Vector3.right * rotateSpeed * Time.deltaTime);
            }

            // rotate to the right on D key press
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }

            // rotate to the left on A key press
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            }
        }
    }

}
