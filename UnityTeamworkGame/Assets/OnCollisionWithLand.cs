using UnityEngine;
using System.Collections;

public class LandSoundController : MonoBehaviour
{
    public AudioClip land;    
                             
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = land;
    }

    void OnCollisionEnter()  
    {
        GetComponent<AudioSource>().Play();
    }
    
}