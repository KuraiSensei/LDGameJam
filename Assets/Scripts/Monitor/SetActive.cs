using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnMouseDown()
    {
        objectToActivate.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeactivateObject()
    {
        objectToActivate.SetActive(false);
        Time.timeScale = 1f;
    }
}

