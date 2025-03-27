using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SavedState : MonoBehaviour
{
    
    [SerializeField] public SceneItems[] stateItems;
    [SerializeField] public ItemDefaults[] defaults;
    private SceneClass[] sceneClasses;


    private void Awake()
    {
        this.setDefaults();
        

    }
    private void setDefaults()
    {
        for (int i = 0; i < defaults.Length; i++)
        {
            stateItems[i].items.AddRange(defaults[i].items);
            stateItems[i].y.AddRange(defaults[i].y);
            stateItems[i].x.AddRange(defaults[i].x);
        }

    }
    

}
