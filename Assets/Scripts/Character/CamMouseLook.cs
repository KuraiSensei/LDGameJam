using UnityEngine;

public class CamMouseLook : MonoBehaviour
{
    Vector2 mouselook; // how much movement the camera has made (total)
    Vector2 smoothV; // smooth down the movement of the mouse
    public float sensitivity = 2.0f; // mouse sensitivity
    public float smoothing = 2.0f; // how much smoothing do you want?

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouselook += smoothV;
        mouselook.y = Mathf.Clamp(mouselook.y, -90f, 90f); // clamp the looking up and down

        // Rotate the camera
        transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);
        transform.localRotation *= Quaternion.AngleAxis(mouselook.x, Vector3.up);
    }
}


