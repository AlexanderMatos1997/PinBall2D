using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] audioFile;

    void Awake()
    {
        foreach(Sound audio in audioFile)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.wavClip;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(audioFile, audio => audio.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
