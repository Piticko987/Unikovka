using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourthKeyhole : DropDetector
{
    private void Open(bool test)
    { if (test) { 
            GameObject obj = GameObject.Find(keyholeName);
        if (obj)
        {
                //GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("celldoor");
                this.GetComponent<Itemclass>().destroyFromMemory();
                obj.GetComponent<changeScene>().SceneChange();
            };
      
    } }

    public void OnMouseUp()
    {
        this.Open(this.testKey());  
    }
}
