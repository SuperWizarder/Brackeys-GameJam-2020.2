using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sound
{
    #region Variables
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spacialBlend;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    #endregion
}