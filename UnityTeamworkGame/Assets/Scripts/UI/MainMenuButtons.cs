using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject InfoPanel;

    public void StartGame()
    {
        EnemyManager.Enemies.Clear();
        PlayerShip.IsDead = false;
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void ContinueGame()
    {
        ////TODO 
    }

    public void OpenOptions()
    {
        this.OptionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        this.OptionsPanel.SetActive(false);
    }

    public void OpenInfo()
    {
        this.InfoPanel.SetActive(true);
    }

    public void CloseInfo()
    {
        this.InfoPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}