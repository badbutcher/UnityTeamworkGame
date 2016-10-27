using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject InfoPanel;

    public void StartGame()
    {
        EnemyManager.Enemies.Clear();
        PlayerStats.IsDead = false;
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

    private void ResetGame()
    {
        PlayerStats.PlayerMoveSpeed = 0.5f;
        PlayerStats.PlayerHealth = 100;
        PlayerStats.PlayerMaxHealth = 100;
        PlayerStats.PlayerCannonBalls = 25;
        PlayerStats.PlayerMaxCannonBalls = 25;
        PlayerStats.PlayerGold = 1000;
        PlayerCannons.maxCannons = 2;
        PlayerCannons.shotCooldown = 0.5f;
    }
}