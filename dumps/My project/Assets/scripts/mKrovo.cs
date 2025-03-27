using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class nKrovo : MonoBehaviour
{
    [SerializeField]
    private string kayName;
    private float distanc;
    private GameObject kay;
    //public void Awake()
    //{
      
    //}
    public void OnMouseUpAsButton()
    {
        kay = GameObject.Find(kayName);
        if (kay)
        {
            distanc = kay.transform.localScale.x;
            if (Vector2.Distance(kay.transform.position, this.transform.position) < distanc)
            {
                this.Unblock();
            }
        }
    }
    //private void OnMouseUp()
    //{
    //   kay =GameObject.Find(kayName);
    //   if(kay){
    //    distanc = kay.transform.localScale.x;
    //    if (Vector2.Distance(kay.transform.position, this.transform.position) < distanc)
    //    {
    //        this.Unblock();
    //    }}
    //}
    private void Unblock()
    {
        this.gameObject.SetActive(false);
        kay.gameObject.SetActive(false);
    }    
  
}

