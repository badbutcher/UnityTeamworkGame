using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    public Slider effects;
    public Slider music;
    public static float currentSoundEffectsValue;
    public static float currentMusicValue;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentSoundEffectsValue = effects.value;
        currentMusicValue = music.value;
    }
}
