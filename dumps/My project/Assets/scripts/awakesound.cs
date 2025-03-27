using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakesound : MonoBehaviour
{
    [SerializeField] private string sound;
    private void Awake()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound(sound);
    }
}
