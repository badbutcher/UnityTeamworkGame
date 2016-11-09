using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public static bool IsDead;
    public static float PlayerMoveSpeed = 0.5f;
    public static float PlayerHealth = 100;
    public static float PlayerMaxHealth = 100f;
    public static float PlayerCannonBalls = 25f;
    public static float PlayerMaxCannonBalls = 25f;
    public static float PlayerGold = 1000f;
    public static float PirateMap = 0f;
    public static float PlayerDmg = 10f;
    public static bool QuestIsActive;
    public bool IsInShop;
    private bool treasureFound;
    public GameObject Crosshair;
    public GameObject Shop;
    public string CurrentIsland;
    public static int QuestShipsKilledCounter;
    public GameObject DontHitIslandsScreen;


    public Animator Animator;
    private AudioSource source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public AudioClip HitLand;


    public static List<string> Zones = new List<string>();
    public static string Zones1;
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

        for (int i = totalZonesFound - 1; i >= 0; i--)
        {
            Zones.Remove(gameObject.name = Zones[i]);
        }


        //for (int i = 0; i < Zones.Count; i++)
       // {
        //    MonoBehaviour.Destroy(GameObject.Find(gameObject.name = Zones[i]));
        //}
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
        Debug.Log(Zones.Count);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        this.CurrentIsland = col.collider.name;
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

        if(col.gameObject.tag == "TreasureChest")
        {
            QuestObject.itemsCollected++;
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Zones")
        {

            QuestObject.zonesFound++;
            if (!Zones.Contains(Zones1))
            {
                Zones.Add(Zones1);
            }
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