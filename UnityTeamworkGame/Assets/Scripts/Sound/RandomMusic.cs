using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomMusic : MonoBehaviour
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

        this.source.volume = SoundSave.CurrentMusicValue;
    }

    IEnumerator RandomSound()
    {
        while (true)
        {
            this.Rnd = Random.Range(0, this.Sounds.Length);
            yield return new WaitForSeconds(Random.Range(120, 240));
            this.source.PlayOneShot(this.Sounds[this.Rnd]);
        }
    }
}