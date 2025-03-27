using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Itemclass : MonoBehaviour
{
    public ScriptableItem item;
    [SerializeField]private ScriptableItem destroy;
    private MasterAudioManager audioManager;
   private  InventoryManager inventoryScript;
    [SerializeField] private bool pickuble=true;
    public void Awake() { 
  
        GameObject inventory =GameObject.Find("MainCanvas");//z�sk� rodi�e scriptu
        inventoryScript = inventory.GetComponent<InventoryManager>() ;
        audioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();//získá odkaz na audioManager script
    }


    public void OnMouseClick()
    {
        Debug.Log("pickuptry");
        if (pickuble) { 
        if (Input.GetMouseButton(1))
        {
                this.pickUp();
        } }
    }
    public void pickUp()
    {
        audioManager.PlaySound("pick_item");
        this.destroyFromMemory();
        this.inventoryScript.PickupItem(this);
    }
    public void destroyFromMemory()
    {
        if (destroy == null) { destroy = item; }
        GameObject.Find("saver").GetComponent<Scenestart>().sceneclass.removeItem(destroy, this.transform.position.x, this.transform.position.y);
    }

 

}
