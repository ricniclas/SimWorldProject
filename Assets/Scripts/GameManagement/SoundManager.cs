using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public float GetVolume(AudioMixerGroup audioMixerGroup)
    {
        float value;
        switch (audioMixerGroup)
        {
            case AudioMixerGroup.MASTER:
                audioMixer.GetFloat(Constants.AUDIO_MIXER_GROUP_MASTER, out value);
                return value;
            case AudioMixerGroup.MUS:
                audioMixer.GetFloat(Constants.AUDIO_MIXER_GROUP_MUS, out value);
                return value;
            case AudioMixerGroup.SFX:
                audioMixer.GetFloat(Constants.AUDIO_MIXER_GROUP_SFX, out value);
                return value;
            default:
                return 0;
        }
    }

    public void SetVolume(AudioMixerGroup audioMixerGroup, float value)
    {
        switch (audioMixerGroup)
        {
            case AudioMixerGroup.MASTER:
                audioMixer.SetFloat(Constants.AUDIO_MIXER_GROUP_MASTER, value);
                break;
            case AudioMixerGroup.MUS:
                audioMixer.SetFloat(Constants.AUDIO_MIXER_GROUP_MUS, value);
                break;
            case AudioMixerGroup.SFX:
                audioMixer.SetFloat(Constants.AUDIO_MIXER_GROUP_SFX, value);
                break;
        }
    }
}

public enum AudioMixerGroup
{
    MASTER,
    MUS,
    SFX
}