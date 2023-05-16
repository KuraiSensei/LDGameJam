/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.lockState = CursorLockMode.None;
        }
    }
} */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private float mouseX, mouseY;
    public float cursorSensitivity = 0.02f;

    private Vector2 desiredMousePos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        desiredMousePos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        // Show cursor in the Unity Editor

    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void LateUpdate()
    {
        float mouseXOffset = (desiredMousePos.x - Screen.width * 0.5f) * cursorSensitivity;
        float mouseYOffset = (desiredMousePos.y - Screen.height * 0.5f) * cursorSensitivity;

        float newXRotation = xRotation + mouseYOffset;
        newXRotation = Mathf.Clamp(newXRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(newXRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseXOffset);

        Cursor.lockState = CursorLockMode.Locked;

        // Hide cursor in build, show cursor in Unity Editor


        desiredMousePos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }
}




