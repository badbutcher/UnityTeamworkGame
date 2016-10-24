using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public float Health;
    public Animator Ani;

    private void Start()
    {
        this.Health = 20;
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
            this.Health -= 5;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.Health -= 10;
        }
    }

    private void RandomHitSounds()
    {
        int rnd = Random.Range(0, this.HitSounds.Length);
        this.Source.PlayOneShot(this.HitSounds[rnd]);
    }
}