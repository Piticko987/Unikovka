using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<changeScene>().SceneChange();
    }
}
