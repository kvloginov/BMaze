using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffects : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public bool makeSoundQuieterOnEnable;
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot quietSnapshot;

    private void OnEnable()
    {
        if (makeSoundQuieterOnEnable)
        {
            quietSnapshot.TransitionTo(0.3f);
        }
    }

    private void OnDisable()
    {
        if (makeSoundQuieterOnEnable)
        {
            normalSnapshot.TransitionTo(0.3f);
        }
    }
}
