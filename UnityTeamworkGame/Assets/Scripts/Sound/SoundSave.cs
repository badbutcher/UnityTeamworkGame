using UnityEngine;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    public Slider Effects;
    public Slider Music;
    public static float CurrentSoundEffectsValue;
    public static float CurrentMusicValue;

    private void Start()
    {
        this.Effects.value = CurrentSoundEffectsValue;
        this.Music.value = CurrentMusicValue;
    }

    private void Update()
    {
        CurrentSoundEffectsValue = this.Effects.value;
        CurrentMusicValue = this.Music.value;
    }
}