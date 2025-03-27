using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField]private float delay;
    [SerializeField]private int scene;
   
    public void SceneChange() {
        
        
        if (delay == 0) { 
        GameObject.Find("saver").GetComponent<Scenestart>().write();
    }
        StartCoroutine(ChangeScene());
       
       
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
    
}
