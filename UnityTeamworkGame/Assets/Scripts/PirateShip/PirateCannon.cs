using UnityEngine;
using System.Collections;

public class PirateCannon : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] ShotSounds;
    public Rigidbody2D CannonBalls;
    public Transform Cannon;
    public GameObject Player;
    public ParticleSystem shotEffect;

    private void Awake()
    {
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.StartCoroutine(this.ShotRandom());
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        var dir = this.Player.transform.position - this.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    private IEnumerator ShotRandom()
    {
        while (!PlayerStats.IsDead)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            StartCoroutine(StopShotEffect());
            Rigidbody2D cannon;
            cannon = Instantiate(this.CannonBalls, this.Cannon.position, this.Cannon.rotation) as Rigidbody2D;
            cannon.AddForce(this.Cannon.right * 50f);
            this.RandomShotSounds();
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