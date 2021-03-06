﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public static bool IsDead;
    public static float PlayerMoveSpeed = 0.5f;
    public static float PlayerHealth = 100f;
    public static float PlayerMaxHealth = 100f;
    public static float PlayerCannonBalls = 50f;
    public static float PlayerMaxCannonBalls = 50f;
    public static float PlayerGold = 1000f;
    public static float PirateMap = 0f;
    public static float PlayerDmg = 10f;
    public static bool QuestIsActive;
    public bool IsInShop;
    private bool treasureFound;
    public GameObject Crosshair;
    public GameObject Shop;
    public GameObject DontHitIslandsScreen;

    public Animator Animator;
    private AudioSource source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public AudioClip HitLand;

    private int totalZonesFound = 6;

    private void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayerDmg = 10;

        if ((SceneManager.GetActiveScene().buildIndex == 2f))
        {
            this.Crosshair.SetActive(true);
        }
        else
        {
            this.Crosshair.SetActive(false);
        }

        PlayerDmg = PlayerDmg - PlayerCannons.MaxCannons + 1;
        DontHitIslandsScreen.SetActive(false);
    }

    private void Update()
    {
        this.source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerHealth <= 0f && IsDead)
        {
            IsDead = true;
            this.source.PlayOneShot(this.DieSound);
        }

        if (PlayerHealth <= 0f && SceneManager.GetActiveScene().buildIndex == 1f)
        {
            IsDead = true;
            DontHitIslandsScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateShipBattle")
        {
            PlayerHealth -= 5f;
        }

        if (col.gameObject.tag == "Terrain")
        {
            PlayerHealth -= 5f;

            if (PlayerHealth > 0)
            {
                this.source.PlayOneShot(this.HitLand);
            }
            else
            {
                SoundSave.CurrentSoundEffectsValue = 0;
            }
        }

        if (col.gameObject.tag == "Dock")
        {
            this.Shop.SetActive(true);
            this.IsInShop = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TreasureChest")
        {
            QuestObject.itemsCollected++;
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Zones")
        {
            IslandManager.Island = col.gameObject.name;
            QuestObject.zonesFound++;
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "PirateCannonBall")
        {
            RandomHitSounds();
            MonoBehaviour.Destroy(col.gameObject);
            PlayerHealth -= PirateShip.PirateShipDmg;
        }

        if (col.gameObject.name == "Treasure" && PirateMap == 5f && !this.treasureFound)
        {
            PlayerGold += 1000f;
            this.treasureFound = true;
        }
    }

    private void RandomHitSounds()
    {
        int rnd = Random.Range(0, this.HitSounds.Length);
        this.source.PlayOneShot(this.HitSounds[rnd]);
    }
}