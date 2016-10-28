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
    }

    void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerStats.PlayerHealth <= 0 && !this.battleLostCheck)
        {
            this.BattleLost();
        }
        if (this.PirateShip.Health <= 0 && !this.battleWonCheck)
        {
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
        yield return new WaitForSeconds(2);
        this.BattleLostScreen.SetActive(true);
        this.Source.PlayOneShot(this.Sounds[0]);
    }

    IEnumerator BattleWonScreenShow()
    {
        int RandomGold = Random.Range(25, 300);
        int RandomHealth = Random.Range(5, 20);
        int RandomCannonBalls = Random.Range(1, 3);
        int RandomValue = Random.Range(1, 5);
        yield return new WaitForSeconds(2);
        this.BattleWonScreen.SetActive(true);
        this.Source.PlayOneShot(this.Sounds[1]);
        if (RandomValue == 1)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + RandomGold;
            PlayerStats.PlayerGold += RandomGold;

        }
        else if (RandomValue == 2)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + RandomGold + "\n- Wood: " + RandomHealth;
            PlayerStats.PlayerGold += RandomGold;
            PlayerStats.PlayerHealth += RandomHealth;
        }
        else if (RandomValue == 3)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + RandomGold + "\n- Wood: " + RandomHealth + "\n- Cannon balls: " + RandomCannonBalls;
            PlayerStats.PlayerGold += RandomGold;
            PlayerStats.PlayerHealth += RandomHealth;
            PlayerStats.PlayerCannonBalls += RandomCannonBalls;
        }
        else if (RandomValue == 4)
        {
            this.SalvagedItemsText.text = "Salvaged Items: " + "\n- Gold: " + RandomGold + "\n- Wood: " + RandomHealth + "\n- Cannon balls: " + RandomCannonBalls + "\n- 1 Map piece";
            PlayerStats.PlayerGold += RandomGold;
            PlayerStats.PlayerHealth += RandomHealth;
            PlayerStats.PlayerCannonBalls += RandomCannonBalls;
            if (PlayerStats.PirateMap != 5)
            {
                PlayerStats.PirateMap++;
            }
        }
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
