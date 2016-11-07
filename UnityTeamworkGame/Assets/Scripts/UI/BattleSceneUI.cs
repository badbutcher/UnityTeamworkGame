using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    public PirateShip PirateShip;
    public PlayerStats PlayerStats;
    private bool battleWonCheck;
    private bool battleLostCheck;
    public GameObject BattleWonScreen;
    public GameObject BattleLostScreen;
    public AudioSource Source;
    public AudioClip[] Sounds;
    public Text SalvagedItemsText;

    void Start()
    {
        this.battleWonCheck = false;
        this.battleLostCheck = false;
        this.BattleWonScreen.SetActive(false);
        this.BattleLostScreen.SetActive(false);
        this.Source = this.GetComponent<AudioSource>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerStats.PlayerHealth <= 0f && !this.battleLostCheck)
        {
            this.BattleLost();
        }

        if (this.PirateShip.PirateShipHealth <= 0f && !this.battleWonCheck)
        {
            if (PlayerStats.QuestIsActive)
            {
                PlayerStats.QuestShipsKilledCounter++;
            }

            this.BattleWon();
        }
    }

    void BattleLost()
    {
        this.battleLostCheck = true;
        this.StartCoroutine(this.BattleLostScreenShow());
    }

    void BattleWon()
    {
        this.battleWonCheck = true;
        this.PirateShip.Source.PlayOneShot(this.PirateShip.DieSound);
        this.PirateShip.Ani.Play("Explode");
        MonoBehaviour.Destroy(this.PirateShip.gameObject, 0.52f);
        this.StartCoroutine(this.BattleWonScreenShow());
    }

    IEnumerator BattleLostScreenShow()
    {
        yield return new WaitForSeconds(2f);
        this.BattleLostScreen.SetActive(true);
        this.Source.PlayOneShot(this.Sounds[0]);
        Time.timeScale = 0f;
    }

    IEnumerator BattleWonScreenShow()
    {
        int randomGold = Random.Range(25, 300);
        int randomHealth = Random.Range(5, 20);
        int randomCannonBalls = Random.Range(1, 3);
        int randomValue = Random.Range(1, 5);
        yield return new WaitForSeconds(2);
        this.BattleWonScreen.SetActive(true);
        this.Source.PlayOneShot(this.Sounds[1]);
        if (randomValue == 1f)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + randomGold;
            PlayerStats.PlayerGold += randomGold;
        }
        else if (randomValue == 2f)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + randomGold + "\n- Wood: " + randomHealth;
            PlayerStats.PlayerGold += randomGold;
            PlayerStats.PlayerHealth += randomHealth;
        }
        else if (randomValue == 3f)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + randomGold + "\n- Wood: " + randomHealth + "\n- Cannon balls: " + randomCannonBalls;
            PlayerStats.PlayerGold += randomGold;
            PlayerStats.PlayerHealth += randomHealth;
            PlayerStats.PlayerCannonBalls += randomCannonBalls;
        }
        else if (randomValue == 4f)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + randomGold + "\n- Wood: " + randomHealth + "\n- Cannon balls: " + randomCannonBalls + "\n- 1 Map piece";
            PlayerStats.PlayerGold += randomGold;
            PlayerStats.PlayerHealth += randomHealth;
            PlayerStats.PlayerCannonBalls += randomCannonBalls;
            if (PlayerStats.PirateMap != 5f)
            {
                PlayerStats.PirateMap++;
            }
        }

        if (PlayerStats.PlayerHealth > PlayerStats.PlayerMaxHealth)
        {
            PlayerStats.PlayerHealth = PlayerStats.PlayerMaxHealth;
        }

        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
