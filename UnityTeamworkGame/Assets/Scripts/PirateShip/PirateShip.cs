using UnityEngine;

public class PirateShip : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] HitSounds;
    public AudioClip DieSound;
    public float PirateShipHealth;
    public static float PirateShipDmg;
    public Animator Ani;

    private void Awake()
    {
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.PirateShipHealth = PlayerStats.PlayerMaxHealth / 5;
        PirateShipDmg = Mathf.Floor(PlayerStats.PlayerDmg * 1.25f);
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.PirateShipHealth -= 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerCannonBall")
        {
            MonoBehaviour.Destroy(col.gameObject);
            this.PirateShipHealth -= PlayerStats.PlayerDmg;
            RandomHitSounds();

            if (PirateShipHealth <= 0)
            {
                PirateShipHealth = 0;
            }

        }
    }

    private void RandomHitSounds()
    {
        int rnd = Random.Range(0, this.HitSounds.Length);
        this.Source.PlayOneShot(this.HitSounds[rnd]);
    }
}