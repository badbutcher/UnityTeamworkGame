using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject InfoPanel;

    public void StartGame()
    {
        ResetGame();
        EnemyManager.Enemies.Clear();
        PlayerStats.IsDead = false;
        SceneManager.LoadSceneAsync("MainScene");
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
        PlayerStats.IsDead = false;
        PlayerStats.PlayerMoveSpeed = 0.5f;
        PlayerStats.PlayerHealth = 100f;
        PlayerStats.PlayerMaxHealth = 100f;
        PlayerStats.PlayerCannonBalls = 25f;
        PlayerStats.PlayerMaxCannonBalls = 25f;
        PlayerStats.PlayerGold = 1000f;
        PlayerCannons.MaxCannons = 2f;
        PlayerCannons.ShotCooldown = 0.5f;
    }
}