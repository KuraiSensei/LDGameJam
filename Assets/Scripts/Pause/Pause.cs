using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenuCanvas.SetActive(!pauseMenuCanvas.activeSelf);
        Time.timeScale = pauseMenuCanvas.activeSelf ? 0f : 1f;
    }
}