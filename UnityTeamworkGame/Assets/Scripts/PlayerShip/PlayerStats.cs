using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static bool IsDead;
    public static float PlayerMoveSpeed = 0.5f;
    public static float PlayerHealth = 100;
    public static float PlayerMaxHealth = 100;
    public static float PlayerCannonBalls = 25;
    public static float PlayerMaxCannonBalls = 25;
    public static float PlayerGold = 1000;
    public static float PirateMap = 0;
    public bool isInShop;
    private bool TreasureFound;
    public GameObject Crosshair;
    public GameObject Shop;

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
        if ((SceneManager.GetActiveScene().buildIndex == 2))
        {
            Crosshair.SetActive(true);
        }
        else
        {
            Crosshair.SetActive(false);
        }
    }

    void Update()
    {
        this.source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerHealth <= 0 && IsDead)
        {
            IsDead = true;
            this.source.PlayOneShot(this.DieSound);
            this.Animator.Play("Explode");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateShipBattle")
        {
            PlayerHealth -= 5;
        }

        if (col.gameObject.tag == "Terrain")
        {
            PlayerHealth -= 5;
            source.PlayOneShot(HitLand);
        }

        if (col.gameObject.tag == "Dock")
        {
            Shop.SetActive(true);
            isInShop = true;
            this.source.PlayOneShot(this.WelcomeSound);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            PlayerHealth -= 10;
        }

        if (col.gameObject.name == "Treasure" && PirateMap == 5 && !TreasureFound)
        {
            PlayerGold += 1000;
            TreasureFound = true;
        }
    }
}
