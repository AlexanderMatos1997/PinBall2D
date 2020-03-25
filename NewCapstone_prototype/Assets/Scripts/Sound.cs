using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip wavClip;

    [Range(0f, 8f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public AudioSource source;
}
