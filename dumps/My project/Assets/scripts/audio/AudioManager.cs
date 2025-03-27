using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected Sound[] sounds;
    protected int masterVolume;
    private MasterAudioManager UniversalAudioManager;
    protected AudioSource SoundSource;

    private void Awake()
    {
        UniversalAudioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();
        SoundSource= this.transform.GetChild(0).GetComponent<AudioSource>();
        PullSynchronizeVolume();
    }
    public void PlaySound(string soundName)
    {
        foreach(Sound s in sounds)
        {
            if (s.Name == soundName)
            {
                SoundSource.clip = s.audio;
                SoundSource.volume = s.volume*this.masterVolume/100;
                SoundSource.Play();
                return;
            }
        }
        
    }
    


    public void PullSynchronizeVolume()
    {
        this.masterVolume=UniversalAudioManager.masterVolume;
    }

}

