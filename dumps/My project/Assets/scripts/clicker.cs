using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class clicker : MonoBehaviour
{
    private int clickCount;
    private readonly int clickCountLimit=5;
    private float lastTime,currentTime;
    private readonly float tolerance = 0.5f;
    private AudioManager audioManager;
 
    void Awake()
    {
        clickCount = clickCountLimit;
        lastTime = Time.realtimeSinceStartup;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }
    public void OnMouseDown()
    {
        audioManager.PlaySound("stonehit");
        currentTime = Time.realtimeSinceStartup;
        if ((currentTime - lastTime) < tolerance)
        {
            clickCount--;
            Debug.Log("stone hitted");
        }
        else {
            clickCount = clickCountLimit;
        }
        lastTime = currentTime;

        if (clickCount == 0)
        {
            this.GetComponent<createItem>().create("Key");
            inwokehint hintGiver =GameObject.Find("hints(Clone)").GetComponent<inwokehint>();
            hintGiver.setHint(5, 4);
            hintGiver.setTimeHint(20, 7, 6);
            this.GetComponent<Itemclass>().pickUp();
            Debug.Log("stone destroyed");
        }
    }
}
