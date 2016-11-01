using UnityEngine;
using System.Collections;

public class PirateCannon : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] ShotSounds;
    public Rigidbody2D CannonBalls;
    public Transform Cannon;
    public GameObject Player;

    private void Start()
    {
        this.Source = this.GetComponent<AudioSource>();
        this.StartCoroutine(this.ShotRandom());
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        var dir = this.Player.transform.position - this.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    IEnumerator ShotRandom()
    {
        while (!PlayerStats.IsDead)
        {
            yield return new WaitForSeconds(Random.Range(1f, 1f));
            Rigidbody2D cannon;
            cannon = Instantiate(this.CannonBalls, this.Cannon.position, this.Cannon.rotation) as Rigidbody2D;
            cannon.AddForce(this.Cannon.right * 50f);
            this.RandomShotSounds();
        }
    }

    private void RandomShotSounds()
    {
        int rnd = Random.Range(0, this.ShotSounds.Length);
        this.Source.PlayOneShot(this.ShotSounds[rnd]);
    }
}