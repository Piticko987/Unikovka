using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MasterAudioManager : AudioManager
{
    [SerializeField] private Sound[] musics;
    private AudioSource MusicSource;
    private void Awake()
    {
        this.masterVolume = 50;
        SoundSource = this.transform.GetChild(0).GetComponent<AudioSource>();
        MusicSource = this.transform.GetChild(1).GetComponent<AudioSource>();
        MusicSource.loop = true;
        PlayMusic("background");

    }

    public void PlayMusic(string soundName)
    {
        foreach (Sound m in musics)
         {
             if (m.Name == soundName)
             {
                 MusicSource.clip = m.audio;
                 MusicSource.name = m.Name;
                 MusicSource.volume = m.volume * this.masterVolume / 100;
                 MusicSource.Play();
                 return;
             }
         }
       

    }
    public void setMasterVolume(float menuVolume)
    {
        this.masterVolume = (int)menuVolume;
        foreach (Sound m in musics)
        {
            if (m.Name == MusicSource.name)
            {
                MusicSource.volume = m.volume * this.masterVolume / 100;
                break;
            }
        }

        this.PushSynchronizeVolume();
    }


    public void PushSynchronizeVolume()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PullSynchronizeVolume();
    }
}
