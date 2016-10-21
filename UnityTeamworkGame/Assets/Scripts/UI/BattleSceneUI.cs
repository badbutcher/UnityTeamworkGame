using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    public Text PlayerHp;
    public PlayerShip PlayerShip;
    public PirateShip PirateShip;
    private bool BattleWonCheck;
    private bool BattleLostCheck;
    public GameObject BattleWonScreen;
    public GameObject BattleLostScreen;

    void Start()
    {
        BattleWonCheck = false;
        BattleLostCheck = false;
        BattleWonScreen.SetActive(false);
        BattleLostScreen.SetActive(false);
    }

    void Update()
    {
        PlayerHp.text = PlayerShip.PlayerMaxHealth + " / " + PlayerShip.PlayerHealth;
        if (PlayerShip.PlayerHealth <= 0 && !BattleLostCheck)
        {
            BattleLost();
        }
        else if (PirateShip.Health <= 0 && !BattleWonCheck)
        {
            BattleWon();
        }
    }

    void BattleLost()
    {
        BattleLostCheck = true;
        PlayerShip.Source.PlayOneShot(PlayerShip.DieSound);
        PlayerShip.Ani.Play("Explode");
        StartCoroutine(BattleLostScreenShow());
    }

    void BattleWon()
    {
        BattleWonCheck = true;
        PirateShip.Source.PlayOneShot(PirateShip.DieSound);
        PirateShip.Ani.Play("Explode");
        MonoBehaviour.Destroy(PirateShip.gameObject, 0.52f);
        StartCoroutine(BattleWonScreenShow());
    }

    IEnumerator BattleLostScreenShow()
    {
        yield return new WaitForSeconds(2);
        BattleLostScreen.SetActive(true);
        //someSound
    }

    IEnumerator BattleWonScreenShow()
    {
        yield return new WaitForSeconds(2);
        BattleWonScreen.SetActive(true);
        //someSound
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
