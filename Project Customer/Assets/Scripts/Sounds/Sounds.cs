using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public AudioMixerGroup audioMixerGroup;

    public string name;

    public AudioClip audioClip;

    public float volume;
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
