using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject Canvas;

    void Start()
    {
        this.Canvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !this.isPaused)
        {
            Time.timeScale = 0f;
            this.isPaused = true;
            this.Canvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && this.isPaused)
        {
            Time.timeScale = 1f;
            this.isPaused = false;
            this.Canvas.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
