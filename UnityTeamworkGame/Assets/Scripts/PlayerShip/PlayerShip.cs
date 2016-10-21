using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public static bool IsDead;
    public float PlayerHealth;
    public float PlayerMaxHealth;
    public Animator Ani;
    public AudioSource Source;
    public AudioClip DieSound;

    private void Start()
    {
        this.PlayerHealth = 20;
        this.PlayerMaxHealth = this.PlayerHealth;
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (this.PlayerHealth <= 0)
        {
            IsDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.PlayerHealth -= 10;
        }

        if (col.gameObject.tag == "PirateShip")
        {
            this.PlayerHealth -= 5;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PirateCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.PlayerHealth -= 10;
        }
    }
}