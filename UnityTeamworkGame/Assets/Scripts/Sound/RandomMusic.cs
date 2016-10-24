using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomMusic : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] Sounds;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        //if (!(SceneManager.GetActiveScene().buildIndex == 0))
        //{
            this.StartCoroutine(this.RandomSound());
        //}

        this.source.volume = SoundSave.CurrentMusicValue;
    }

    IEnumerator RandomSound()
    {
        while (true)
        {
            int Rnd = Random.Range(0, this.Sounds.Length);
            this.source.PlayOneShot(this.Sounds[Rnd]);
            yield return new WaitForSeconds(240);  
        }
    }
}