﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject QuestPanel;
    public Text PlayerGoldText;
    public Text PlayerHpText;
    public Text PlayerCannonBallsText;
    public PlayerStats PlayerStats;

    void Start()
    {
        QuestPanel.SetActive(false);
    }

    void Update()
    {
        PlayerGoldText.text = PlayerStats.PlayerGold.ToString();
        PlayerHpText.text = PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
        PlayerCannonBallsText.text = PlayerStats.PlayerCannonBalls + " / " + PlayerStats.PlayerMaxCannonBalls;
    }

    public void ShowQuests()
    {
        QuestPanel.SetActive(true);
    }

    public void HideQuests()
    {
        QuestPanel.SetActive(false);
    }
}