using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject InfoPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ContinueGame()
    {
        //TODO 
    }

    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
    }

    public void OpenInfo()
    {
        InfoPanel.SetActive(true);
    }

    public void CloseInfo()
    {
        InfoPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
