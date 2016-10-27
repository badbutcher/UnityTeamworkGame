﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    public Text PlayerHp;
    public PirateShip PirateShip;
    public PlayerStats PlayerStats;
    private bool battleWonCheck;
    private bool battleLostCheck;
    public GameObject BattleWonScreen;
    public GameObject BattleLostScreen;
    public AudioSource Source;
    public AudioClip[] Sounds;

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
        PlayerHp.text = PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
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
        yield return new WaitForSeconds(2);
        this.BattleWonScreen.SetActive(true);
        this.Source.PlayOneShot(this.Sounds[1]);
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
