using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepUI : MonoBehaviour {


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<keepUI>().Length; i++)
            if (Object.FindObjectsOfType<keepUI>()[i] != this) {
        if (Object.FindObjectsOfType<keepUI>()[i].name == gameObject.name)
        {
            Destroy(gameObject);
        } }
        DontDestroyOnLoad(this);
    }
    //only to synschronize framerate in unity editor dat pryc v buildu
    public int target = 60;

    void Awake()
    {
        if (this.target != 0) { 
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = target;
    }
    }

    void Update()
    {
        if (this.target != 0)
        {
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
        }
    }


}
