using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioMixer audioMixer;

    private float masterVolume = 0.0f;
    private float musicVolume = 0.0f;
    private float sfxVolume = 0.0f;

    public float MasterVolume
    {
        get => masterVolume;
        set 
        { 
            masterVolume = Mathf.Clamp(value, -80f, 20f);
        }
    }

    public float MusicVolume 
    {
        get => musicVolume;
        set 
        { 
            musicVolume = Mathf.Clamp(value, -80f, 20f);
        } 
    }

    public float SFXVolume
    {
        get => sfxVolume;
        set
        {
            sfxVolume = Mathf.Clamp(value, -80f, 20f);
        }
    }

    private void Update()
    {
        audioMixer.SetFloat("Master", MasterVolume);
        audioMixer.SetFloat("Music", MusicVolume);
        audioMixer.SetFloat("SFX", SFXVolume);
    }
}
