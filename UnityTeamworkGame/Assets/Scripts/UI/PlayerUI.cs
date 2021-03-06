﻿using UnityEngine;
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

    private void Start()
    {
        this.QuestPanel.SetActive(false);
        this.MapPanel.SetActive(false);
        if ((SceneManager.GetActiveScene().buildIndex == 2f))
        {
            this.EnemyHealth.SetActive(true);
        }
        else
        {
            this.EnemyHealth.SetActive(false);
        }
    }

    private void Update()
    {
        this.EnemyHealthText.text = PirateShip.PirateShipHealth.ToString();
        this.PlayerGoldText.text = PlayerStats.PlayerGold.ToString();
        this.PlayerHpText.text = PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
        this.PlayerCannonBallsText.text = PlayerStats.PlayerCannonBalls + " / " + PlayerStats.PlayerMaxCannonBalls;
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
