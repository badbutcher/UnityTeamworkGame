using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] sounds;
    public int rnd;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {

        if (!(SceneManager.GetActiveScene().buildIndex == 0))
        {
            StartCoroutine(RandomSound());
        }
        source.volume = SoundSave.currentSoundEffectsValue;
    }

    IEnumerator RandomSound()
    {
        while (true)
        {
            rnd = Random.Range(0, sounds.Length);
            yield return new WaitForSeconds(Random.Range(20,30));
            source.PlayOneShot(sounds[rnd]);
        }
    }
}