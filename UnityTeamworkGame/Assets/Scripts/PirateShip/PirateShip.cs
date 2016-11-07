using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public float PirateShipHealth;
    public static float PirateShipDmg;
    public Animator Ani;

    private void Start()
    {
        this.PirateShipHealth = PlayerStats.PlayerMaxHealth / 5;
        PirateShipDmg = Mathf.Floor(PlayerStats.PlayerDmg * 1.25f);
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.PirateShipHealth -= 5f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.PirateShipHealth -= PlayerStats.PlayerDmg;
            RandomHitSounds();
        }
    }

    private void RandomHitSounds()
    {
        int rnd = Random.Range(0, this.HitSounds.Length);
        this.Source.PlayOneShot(this.HitSounds[rnd]);
    }
}