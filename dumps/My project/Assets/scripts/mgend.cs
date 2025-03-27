using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mgend : MonoBehaviour
{
    [SerializeField] string destroy;
    //[SerializeField] changeScene ui;
    private GameObject d;


    public void finish()
    {
        //ui = GameObject.Find("UIManager").GetComponent<changeScene>();
        //ui.SceneChange(2,5);
        SceneManager.LoadScene(1);
        getstuf();
    }

    private void getstuf()
    {
        try
        {
            d = GameObject.Find(destroy);
            //Destroy(d);
            d.SetActive(false);
            //Debug.Log(d.activeSelf);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}
