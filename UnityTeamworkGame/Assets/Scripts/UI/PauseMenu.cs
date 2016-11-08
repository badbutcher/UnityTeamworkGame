using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject Canvas;

    private void Start()
    {
        this.Canvas.SetActive(false);
    }

    private void Update()
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
