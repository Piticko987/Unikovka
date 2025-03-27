using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menufunctions : MonoBehaviour
{
    private MasterAudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("PPU");
    }
    public void Test()
    {
        Debug.Log("Zmaèknuto");
    }
    public void click()
    {
        audioManager.PlaySound("click");
    }
    
}
