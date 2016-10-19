using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public static bool BattleWon;
    public float Health;
    public Animator Ani;
    public int Rnd;

    private void Start()
    {
        this.Health = 120;
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        if (this.Health <= 0)
        {
            if (!BattleWon)
            {
                Source.PlayOneShot(DieSound);
                BattleWon = true;
            }
            this.Ani.Play("Explode");    
            MonoBehaviour.Destroy(this.gameObject, 0.52f);
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.Health -= 10;
            RandomHitSounds();
        }
    }

    private void RandomHitSounds()
    {
        this.Rnd = Random.Range(0, this.HitSounds.Length);
        this.Source.PlayOneShot(this.HitSounds[this.Rnd]);
    }
}