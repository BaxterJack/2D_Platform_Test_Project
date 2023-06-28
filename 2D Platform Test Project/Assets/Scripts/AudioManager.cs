using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField]
    Sound[] sounds;
    [SerializeField]
    Sound[] themes;

    public Sound Theme = null;

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }

        foreach (Sound s in themes)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }

    }

    public void PlaySound(String name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Play();
       
    }

    public void PlayTheme(String name)
    {
        Theme = Array.Find(themes, s => s.name == name);
        Theme.audioSource.Play();
    }

    public void StopTheme()
    {
        if(Theme.audioSource == null) // why does this not work, have to assign a theme in start method?
        {
            return;
        }
        Theme.audioSource.Stop();
    }
}
