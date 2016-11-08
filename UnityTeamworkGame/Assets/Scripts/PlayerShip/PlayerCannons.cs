using System.Collections;
using UnityEngine;

public class PlayerCannons : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] ShotSounds;
    public Rigidbody2D CannonBalls;
    public Transform[] Cannons;
    public float CanShot = 0;
    public static float ShotCooldown = 0.5f;
    public static float MaxCannons = 2f;
    public PlayerStats PlayerStats;
    public ParticleSystem shotEffect;

    private void Awake()
    {
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && Time.time > this.CanShot + ShotCooldown && PlayerStats.PlayerCannonBalls > 0f)
        {
            StartCoroutine(StopShotEffect());
            Rigidbody2D cannon;
            for (int i = 0; i < this.Cannons.Length - MaxCannons; i++)
            {
                PlayerStats.PlayerCannonBalls--;
                cannon = Instantiate(this.CannonBalls, this.Cannons[i].position, this.Cannons[i].rotation) as Rigidbody2D;
                cannon.AddForce(this.Cannons[i].right * 50f);
                this.RandomShotSounds();
                this.CanShot = Time.time;
            }
        }
    }

    private IEnumerator StopShotEffect()
    {
        shotEffect.Play();
        yield return new WaitForSeconds(0.1f);
        shotEffect.Stop();
    }

    private void RandomShotSounds()
    {
        int rnd = Random.Range(0, this.ShotSounds.Length);
        this.Source.PlayOneShot(this.ShotSounds[rnd]);
    }
}