using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : MonoBehaviour
{

    public void SetMUSVolume(float input)
    {
        setMixerVolume(input, AudioMixerGroup.MUS);
    }

    public void SetSFXVolume(float input)
    {
        setMixerVolume(input, AudioMixerGroup.SFX);
    }

    public void SetMasterVolume(float input)
    {
        setMixerVolume(input, AudioMixerGroup.MASTER);
    }

    private void setMixerVolume(float volume,AudioMixerGroup audioMixerGroup)
    {
        GameManager.Instance.soundManager.SetVolume(audioMixerGroup, Mathf.Log10(volume) * 20);
    }
}
