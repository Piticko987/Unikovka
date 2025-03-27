using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstkeyhole : DropDetector
{
    private void Open(bool test)
    { if (test) { 
            GameObject obj = GameObject.Find(keyholeName);
        if (obj)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("celldoor");
            obj.GetComponent<Itemclass>().destroyFromMemory();
            Destroy(obj);
        };
            this.GetComponent<Itemclass>().destroyFromMemory();
        //odebere item z uložených itemù sceny
        Destroy(this.gameObject);
    } }

    public void OnMouseUp()
    {
        this.Open(this.testKey());  
    }
}
