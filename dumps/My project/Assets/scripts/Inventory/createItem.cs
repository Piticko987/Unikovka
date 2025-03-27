using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createItem : MonoBehaviour
{
    public void create(string Name_path, Vector3 ItemPosition)
    {
         
        GameObject Object = Instantiate(Resources.Load(Name_path)) as GameObject;
        Object.transform.position = ItemPosition;
        GameObject.Find("saver").GetComponent<Scenestart>().sceneclass.AddItem(Object.GetComponent<Itemclass>().item, ItemPosition.x, ItemPosition.y);
        Object.gameObject.SetActive(true);
    
    }
    public void create(string Name_path)
    {
       
            GameObject Object = Instantiate(Resources.Load(Name_path)) as GameObject;
            Vector3 ItemPosition = Object.transform.position;
            GameObject.Find("saver").GetComponent<Scenestart>().sceneclass.AddItem(Object.GetComponent<Itemclass>().item, ItemPosition.x, ItemPosition.y);
            Object.gameObject.SetActive(true);
        
    }
}

