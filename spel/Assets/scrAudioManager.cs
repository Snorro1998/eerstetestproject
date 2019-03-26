﻿using UnityEngine;
using System;
using UnityEngine.Audio;

public class scrAudioManager : MonoBehaviour {

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        playSound("Music");
    }

    public void playSound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}