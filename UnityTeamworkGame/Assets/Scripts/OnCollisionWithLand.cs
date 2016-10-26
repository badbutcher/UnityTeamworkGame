using UnityEngine;
using System.Collections;

public class OnCollisionWithLand : MonoBehaviour
{
    public AudioClip land;    
                             
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = land;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Character")
        {
            GetComponent<AudioSource>().Play();
        }
    }

}