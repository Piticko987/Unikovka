using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using static UnityEditor.Progress;

public class DropDetector : MonoBehaviour
{
    [SerializeField]
    protected string keyholeName;
    protected float distance=0.1f;
    protected GameObject keyhole;
    public bool testKey()
    {
        try {
       keyhole = GameObject.Find(keyholeName);
        if (keyhole) {
            distance = keyhole.transform.localScale.x/3;
            if (Vector2.Distance(keyhole.transform.position, this.transform.position) < distance)
            {
                    return true;
            } } return false;
        }
    catch(NullReferenceException e) { Debug.Log(e.Message);return false; }
    }
    
  
}

