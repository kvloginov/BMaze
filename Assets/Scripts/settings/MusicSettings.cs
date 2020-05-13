using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public AudioMixerGroup mixer;
    private const string ENABLED_SUFFIX = "Enabled";

    public void OnEnable()
    {
        
    }

    public void Start()
    {
        var toggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            // константы - боль
            if (toggle.gameObject.name == "Music")
            {
                toggle.isOn = PlayerPrefs.GetInt("MusicVolumeEnabled", 1) == 1;
            } 
            else if (toggle.gameObject.name == "Sfx")
            {
                toggle.isOn = PlayerPrefs.GetInt("EffectsVolumeEnabled", 1) == 1;
            }
        }
    }

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
            PlayerPrefs.SetInt(mixerName + ENABLED_SUFFIX, 1);
        }
        else
        {
            mixer.audioMixer.SetFloat(mixerName, -80);
            PlayerPrefs.SetInt(mixerName + ENABLED_SUFFIX, 0);
        }
    }
}
