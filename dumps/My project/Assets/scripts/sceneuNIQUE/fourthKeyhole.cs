using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondKeyHole : DropDetector
{
    private void Open(bool test)
    { if (test) { 
            GameObject obj = GameObject.Find(keyholeName);
        if (obj)
        {
                //GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("celldoor");
                obj.GetComponent<Itemclass>().destroyFromMemory();
                Destroy(obj.gameObject);
        };
            this.GetComponent<Itemclass>().destroyFromMemory();
            Destroy(this.gameObject);
            GameObject krovo = GameObject.Find("blokada4th(Clone)");
            krovo.GetComponent<Itemclass>().destroyFromMemory();
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("burn");
            Destroy(krovo);

        } }

    public void OnMouseUp()
    {
        this.Open(this.testKey());  
    }
}
