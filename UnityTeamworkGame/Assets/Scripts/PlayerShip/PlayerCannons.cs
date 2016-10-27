using UnityEngine;

public class PlayerCannons : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] ShotSounds;
    public Rigidbody2D CannonBalls;
    public Transform[] Cannons;
    public float canShot = 0;
    public static float shotCooldown = 0.5f;
    public static float maxCannons = 2;
    public PlayerStats PlayerStats;

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

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && Time.time > this.canShot + shotCooldown && PlayerStats.PlayerCannonBalls > 0)
        {
            Rigidbody2D cannon;
            for (int i = 0; i < this.Cannons.Length - maxCannons; i++)
            {
                PlayerStats.PlayerCannonBalls--;
                cannon = Instantiate(this.CannonBalls, this.Cannons[i].position, this.Cannons[i].rotation) as Rigidbody2D;
                cannon.AddForce(this.Cannons[i].right * 50f);
                this.RandomShotSounds();
                this.canShot = Time.time;
            }
        }
    }

    private void RandomShotSounds()
    {
        int rnd = Random.Range(0, this.ShotSounds.Length);
        this.Source.PlayOneShot(this.ShotSounds[rnd]);
    }
}