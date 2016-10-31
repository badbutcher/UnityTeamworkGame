using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject QuestPanel;
    public GameObject MapPanel;
    public Text PlayerGoldText;
    public Text PlayerHpText;
    public Text PlayerCannonBallsText;
    public PlayerStats PlayerStats;
    public GameObject[] MapParts;
    public Text CurrentQuest;

    void Start()
    {
        QuestPanel.SetActive(false);
        MapPanel.SetActive(false);
    }

    void Update()
    {
        PlayerGoldText.text = PlayerStats.PlayerGold.ToString();
        PlayerHpText.text = PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
        PlayerCannonBallsText.text = PlayerStats.PlayerCannonBalls + " / " + PlayerStats.PlayerMaxCannonBalls;
        if (PlayerStats.QuestIsActive)
        {
            CurrentQuest.text = "Desotroy " + ShopButtons.ShipsToDestroyQuest +
                " pirate ships for " + ShopButtons.RewardQuest +
                "G (" + PlayerStats.questShipsKilledCounter + "/" + ShopButtons.ShipsToDestroyQuest + ")";
        }
        if (PlayerStats.questShipsKilledCounter == ShopButtons.ShipsToDestroyQuest)
        {
            PlayerStats.questShipsKilledCounter = 0;
            CurrentQuest.text = string.Empty;
            PlayerStats.PlayerGold += ShopButtons.RewardQuest;
            PlayerStats.QuestIsActive = false;
        }
    }

    public void ShowQuests()
    {
        QuestPanel.SetActive(true);
    }

    public void HideQuests()
    {
        QuestPanel.SetActive(false);
    }

    public void ShowMap()
    {
        MapPanel.SetActive(true);
        for (int i = 0; i < PlayerStats.PirateMap; i++)
        {
            MapParts[i].SetActive(true);
        }
    }

    public void HideMap()
    {
        MapPanel.SetActive(false);
    }
}
