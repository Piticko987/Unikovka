using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mSouhvezdi : MonoBehaviour
{
    [SerializeField] private ScriptableItem[] itemsrm;
    [SerializeField] private float[] rmx;
    [SerializeField] private float[] rmy;
    [SerializeField] private ScriptableItem[] items;
    [SerializeField] private float[] x;
    [SerializeField] private float[] y;
    GameObject gg;
    private void Awake()
    {
        gg = GameObject.Find("movement");
        gg.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
    }
    public void kontrola()
    {
        //String v = GameObject.Find("Text").GetComponent<TMP_Text>().text.ToString();
        String b = GameObject.Find("heslo").GetComponent<TMP_InputField>().text;
        /*Debug.Log(GameObject.Find("Text").GetComponent<TMP_Text>().text.ToString().GetType());
        Debug.Log(v.GetType());
        Debug.Log(GameObject.Find("heslo").GetComponent<TMP_Text>().text.ToString().Equals("rak"));
        Debug.Log(String.Compare(GameObject.Find("Text").GetComponent<TMP_Text>().text.ToString(),"rak"));*/
        //Debug.Log(string);
        //Debug.Log(v.Trim() == "rak");
        //Debug.Log(v);
        //Debug.Log(b);
        if (b == "rak"||b == "Rak"||b=="RAK")
        {
            gg.SetActive(true);
            GameObject.Find("saver").GetComponent<minigaeExit>().change(items, x, y, itemsrm, rmx, rmy);
            SceneManager.LoadScene(6);
        }
    }
}
