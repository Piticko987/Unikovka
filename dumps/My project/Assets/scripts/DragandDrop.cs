using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DragandDrop : MonoBehaviour
{

    private Camera cam;
    private Vector3 offset;
    private Scenestart script;
    private ScriptableItem item;
    public void Awake()
    {
        cam = Camera.main;

    }
    public void OnMouseDown()
    {
        script = GameObject.Find("saver").GetComponent<Scenestart>();
        this.item = this.GetComponent<Itemclass>().item;
        script.sceneclass.removeItem(this.item, this.transform.position.x, this.transform.position.y);
        offset = transform.position - CurrentMousePosition();
    }
    public Vector3 CurrentMousePosition()
    {
       Vector3 Position = cam.ScreenToWorldPoint(Input.mousePosition);
        Position.z = 1;

        return Position;
    }
  
 
    public void OnMouseDrag()
    {
        transform.position = CurrentMousePosition()+offset;
    }
    public void OnMouseUp()
    {
            script.sceneclass.AddItem(this.item, this.transform.position.x, this.transform.position.y);
    }

}
