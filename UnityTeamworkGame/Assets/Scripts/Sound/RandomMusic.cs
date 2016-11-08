using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomMusic : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] Sounds;

    private void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.StartCoroutine(this.RandomSound());
        this.source.volume = SoundSave.CurrentMusicValue;
    }

    private IEnumerator RandomSound()
    {
        while (true)
        {
            int rnd = Random.Range(0, this.Sounds.Length);
            this.source.PlayOneShot(this.Sounds[rnd]);
            yield return new WaitForSeconds(240f);
        }
    }
}