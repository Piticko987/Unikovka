using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class Outputslot : MonoBehaviour,IDropHandler
{
    public ScriptableItem item;
    private Camera cam;
    private createItem CreateItem;
    private MasterAudioManager audioManager;

    public void Awake(){
        this.cam=Camera.main;
        this.CreateItem = this.GetComponent<createItem>();
        audioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();//získá odkaz na audioManager script
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        GameObject Dropped = eventData.pointerDrag;
        InventoryActions script = Dropped.GetComponent<InventoryActions>();//z�sk� z dropped cestu na instanci a z n� hodlotu dfs
        if (script.DraggedFromSlot == null)//zaji�tuje aby nedo�lo k nullrefferenceexception
        { return; }
        Slotclass ParentSlot = script.DraggedFromSlot.GetComponent<Slotclass>();
        if (ParentSlot == this) { return; }
        if (ParentSlot.item != null)//zaji�tuje aby nedo�lo k nullrefferenceexception p�i p�emisteni slotu do sebe sameho
        {
            this.item = ParentSlot.item;
            ParentSlot.emptySlot();



            Vector3 ItemPosition = this.cam.ScreenToWorldPoint(Input.mousePosition);
            ItemPosition.z = 0;
            if (item.path != "") { 
            CreateItem.create(item.path, ItemPosition);
            audioManager.PlaySound("pick_item");
            }
            else
            {
                ParentSlot.item = item;
               
            }
        }
        }
    }

