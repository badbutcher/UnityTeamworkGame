using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            Canvas.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            Canvas.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
