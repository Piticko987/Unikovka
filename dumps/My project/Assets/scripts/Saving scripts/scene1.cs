using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
//using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Scenestart : MonoBehaviour
{
 
    [SerializeField]protected SceneItems scenestate;
    public SceneClass sceneclass;
    
   private void Awake(){
        sceneclass = new SceneClass();
        
        this.read();
        for(int i=0;i<scenestate.items.Count;i++){
            
                GameObject NewObject = Instantiate(Resources.Load((string)scenestate.items[i])) as GameObject;
            
                NewObject.transform.position = new Vector3((float)scenestate.x[i], (float)scenestate.y[i], 0);
            
                NewObject.gameObject.SetActive(true);
            
        }
    }
    public void write()
    {
        scenestate.items = sceneclass.itemy;
        scenestate.x = sceneclass.x;
        scenestate.y = sceneclass.y;


    }
  protected void read()
    {
        sceneclass.itemy.Clear();
        sceneclass.x.Clear();
        sceneclass.y.Clear();
        for (int i = 0; i < scenestate.items.Count; i++)
        {
          
                sceneclass.itemy.Add(scenestate.items[i]);
                sceneclass.x.Add(scenestate.x[i]);
                sceneclass.y.Add(scenestate.y[i]);
          

        }
    }
}

public class SceneClass
{
    public ArrayList itemy=new ArrayList();
    public ArrayList x = new ArrayList();
    public ArrayList y = new ArrayList();

    public void AddItem(ScriptableItem item,float x,float y)
    {
        this.itemy.Add(item.path);
        this.x.Add(x);
        this.y.Add(y);
    }
    public void removeItem(ScriptableItem item, float x, float y)
    {
        for(int i = 0; i < itemy.Count; i++)
        {
            if (((string)itemy[i]== item.path) && ((float)this.x[i] == x) && ((float)this.y[i] == y))
            {
                this.x.RemoveAt(i);
                this.y.RemoveAt(i);
                this.itemy.RemoveAt(i);
            }
        }

    }
   
}
