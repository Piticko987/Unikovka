using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigaeExit : Scenestart
{
    private void Awake()
    {
        this.sceneclass = new SceneClass();

        this.read();
    }
    public void change(ScriptableItem[] items, float[] x, float[] y, ScriptableItem[] itemsrm, float[] rmx, float[] rmy)
    {
        for (int i = 0; i < items.Length; i++) { 
        sceneclass.AddItem(items[i], x[i], y[i]); }
        for (int i = 0; i < items.Length; i++)
        {
            sceneclass.removeItem(itemsrm[i], rmx[i], rmy[i]);
        }
        this.write();
    }
}
