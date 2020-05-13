using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSettings : MonoBehaviour
{
    public AudioMixerGroup mixer;

    public void ToggleMusic(bool enabled)
    {
        toggle("MusicVolume", enabled);
    }

    public void ToggleSfx(bool enabled)
    {
        toggle("EffectsVolume", enabled);
    }

    private void toggle(string mixerName ,bool enabled)
    {
        if (enabled)
        {
            mixer.audioMixer.SetFloat(mixerName, 0);
        }
        else
        {
            mixer.audioMixer.SetFloat(mixerName, -80);
        }
    }
}
