using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class Sound
{
    public string Name;
    public AudioClip audio;

    [Range(0f, 1f)]
    public float volume;

}
