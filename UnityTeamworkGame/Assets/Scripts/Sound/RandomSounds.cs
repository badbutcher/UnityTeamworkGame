using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomSounds : MonoBehaviour
{
    private AudioSource source;

    public AudioClip[] Sounds;
    public int Rnd;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        if (!(SceneManager.GetActiveScene().buildIndex == 0))
        {
            this.StartCoroutine(this.RandomSound());
        }

        this.source.volume = SoundSave.CurrentSoundEffectsValue;
    }

    IEnumerator RandomSound()
    {
        while (true)
        {
            this.Rnd = Random.Range(0, this.Sounds.Length);
            yield return new WaitForSeconds(Random.Range(1, 3));
            this.source.PlayOneShot(this.Sounds[this.Rnd]);
        }
    }
}