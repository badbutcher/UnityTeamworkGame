using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public GameObject QuestPanel;
    public GameObject MapPanel;
    public GameObject EnemyHealth;
    public Text PlayerGoldText;
    public Text PlayerHpText;
    public Text PlayerCannonBallsText;
    public Text EnemyHealthText;
    public PlayerStats PlayerStats;
    public PirateShip PirateShip;
    public GameObject[] MapParts;
    public Text CurrentQuest;

    void Start()
    {
        this.QuestPanel.SetActive(false);
        this.MapPanel.SetActive(false);
        if ((SceneManager.GetActiveScene().buildIndex == 2f))
        {
            EnemyHealth.SetActive(true);
        }
        else
        {
            EnemyHealth.SetActive(false);
        }
    }

    void Update()
    {
        EnemyHealthText.text = PirateShip.PirateShipHealth.ToString();
        this.PlayerGoldText.text = PlayerStats.PlayerGold.ToString();
        this.PlayerHpText.text = PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
        this.PlayerCannonBallsText.text = PlayerStats.PlayerCannonBalls + " / " + PlayerStats.PlayerMaxCannonBalls;
        if (PlayerStats.QuestIsActive)
        {
            CurrentQuest.text = "Desotroy " + ShopButtons.ShipsToDestroyQuest +
                " pirate ships for " + ShopButtons.RewardQuest +
                "G (" + PlayerStats.QuestShipsKilledCounter + "/" + ShopButtons.ShipsToDestroyQuest + ")";
        }

        if (PlayerStats.QuestShipsKilledCounter == ShopButtons.ShipsToDestroyQuest)
        {
            PlayerStats.QuestShipsKilledCounter = 0;
            this.CurrentQuest.text = string.Empty;
            PlayerStats.PlayerGold += ShopButtons.RewardQuest;
            PlayerStats.QuestIsActive = false;
        }
    }

    public void ShowQuests()
    {
        this.QuestPanel.SetActive(true);
    }

    public void HideQuests()
    {
        this.QuestPanel.SetActive(false);
    }

    public void ShowMap()
    {
        this.MapPanel.SetActive(true);
        for (int i = 0; i < PlayerStats.PirateMap; i++)
        {
            MapParts[i].SetActive(true);
        }
    }

    public void HideMap()
    {
        this.MapPanel.SetActive(false);
    }
}
