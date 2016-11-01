﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static bool IsDead;
    public static float PlayerMoveSpeed = 0.5f;
    public static float PlayerHealth = 100f;
    public static float PlayerMaxHealth = 100f;
    public static float PlayerCannonBalls = 25f;
    public static float PlayerMaxCannonBalls = 25f;
    public static float PlayerGold = 1000f;
    public static float PirateMap = 0f;
    public static bool QuestIsActive;
    public bool IsInShop;
    private bool treasureFound;
    public GameObject Crosshair;
    public GameObject Shop;
    public string CurrentIsland;
    public static int QuestShipsKilledCounter;

    public Animator Animator;
    private AudioSource source;
    public AudioClip DieSound;
    public AudioClip HitLand;
    public AudioClip WelcomeSound;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 2f))
        {
            this.Crosshair.SetActive(true);
        }
        else
        {
            this.Crosshair.SetActive(false);
        }
    }

    void Update()
    {
        this.source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerHealth <= 0f && IsDead)
        {
            IsDead = true;
            this.source.PlayOneShot(this.DieSound);
            this.Animator.Play("Explode");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.CurrentIsland = col.collider.name;
        if (col.gameObject.tag == "PirateShipBattle")
        {
            PlayerHealth -= 5f;
        }

        if (col.gameObject.tag == "Terrain")
        {
            PlayerHealth -= 5f;
            this.source.PlayOneShot(this.HitLand);
        }

        if (col.gameObject.tag == "Dock")
        {
            this.Shop.SetActive(true);
            this.IsInShop = true;
            this.source.PlayOneShot(this.WelcomeSound);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            PlayerHealth -= 10f;
        }

        if (col.gameObject.name == "Treasure" && PirateMap == 5f && !this.treasureFound)
        {
            PlayerGold += 1000f;
            this.treasureFound = true;
        }
    }
}
