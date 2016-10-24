using UnityEngine;

public class PlayerCannons : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] ShotSounds;
    public Rigidbody2D CannonBalls;
    public Transform Cannon;

    private void Start()
    {
        this.Source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.Source.volume = SoundSave.CurrentSoundEffectsValue;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
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