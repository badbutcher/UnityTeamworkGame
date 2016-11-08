using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] Sounds;

    private void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!(SceneManager.GetActiveScene().buildIndex == 0))
        {
            this.StartCoroutine(this.RandomSound());
        }

        this.source.volume = SoundSave.CurrentSoundEffectsValue;
    }

    private IEnumerator RandomSound()
    {
        while (true)
        {
            int rnd = Random.Range(0, this.Sounds.Length);
            yield return new WaitForSeconds(Random.Range(1, 3));
            this.source.PlayOneShot(this.Sounds[rnd]);
        }
    }
}