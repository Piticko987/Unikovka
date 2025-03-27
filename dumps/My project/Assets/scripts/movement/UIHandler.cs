using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler: MonoBehaviour
{
    private cameraMove CameraMove;
    
  
    private void Awake()
    {
        CameraMove = gameObject.GetComponentInParent<cameraMove>();//získá smer na script cameraHandleru
    }
    public void left() {
        move(0);
    }
    public void right()
    {
        this.move(1);
    }
    public void up()
    {
        this.move(2);
    }
    public void down()
    {
        this.move(3);
    }
    public void move(int val)
    {
        switch (val)
        {
            case 0:
                CameraMove.setHort(-1);
                break;
            case 1:
                CameraMove.setHort(1);
                break;
            case 2:
                    CameraMove.setVert(1);
                break;
            case 3:
                    CameraMove.setVert(-1);
                break;
        }
    }
    public void Reset()
    {
        CameraMove.setVert(0);
        CameraMove.setHort(0);
    }

}
