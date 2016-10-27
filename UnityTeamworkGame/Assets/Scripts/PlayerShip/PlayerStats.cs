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
    public GameObject Crosshair;

    public Animator Animator;
    public AudioSource Source;
    public AudioClip DieSound;

    void Awake()
    {
        this.Source = this.GetComponent<AudioSource>();
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
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        if (PlayerHealth <= 0 && IsDead)
        {
            IsDead = true;
            this.Source.PlayOneShot(this.DieSound);
            this.Animator.Play("Explode");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateShipBattle")
        {
            PlayerHealth -= 5;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            PlayerHealth -= 10;
        }
    }
}
