using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioMixer audioMixer;

    private float masterVolume = 1.0f;
    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;

    public float MasterVolume
    {
        get => masterVolume;
        set 
        { 
            masterVolume = Mathf.Clamp01(value);
        }
    }

    public float MusicVolume 
    {
        get => musicVolume;
        set 
        { 
            musicVolume = Mathf.Clamp01(value);
        } 
    }

    public float SFXVolume
    {
        get => sfxVolume;
        set
        {
            sfxVolume = Mathf.Clamp01(value);
        }
    }

    private void Start()
    {
        SFXVolume = 0.5f;
    }

    private void Update()
    {
        audioMixer.SetFloat("Master", MasterVolume);
        audioMixer.SetFloat("Music", MusicVolume);
        audioMixer.SetFloat("SFX", SFXVolume);
    }
}
