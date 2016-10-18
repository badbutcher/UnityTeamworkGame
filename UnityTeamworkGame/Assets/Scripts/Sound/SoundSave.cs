using UnityEngine;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    public Slider Effects;
    public Slider Music;
    public static float CurrentSoundEffectsValue;
    public static float CurrentMusicValue;

    void Start()
    {
    }

    void Update()
    {
        CurrentSoundEffectsValue = this.Effects.value;
        CurrentMusicValue = this.Music.value;
    }
}