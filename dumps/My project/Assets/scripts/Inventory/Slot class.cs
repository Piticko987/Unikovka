using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slotclass : MonoBehaviour,IDropHandler
{
    public ScriptableItem item;
    private RawImage icon;
    [SerializeField] private bool special = false;
    private MasterAudioManager audioManager;

    private void Awake()
    {
        this.audioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();
    }

    public void SetValues()
    {

        if (item == null) {
            transform.GetChild(0).gameObject.SetActive(false); 
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            icon = this.GetComponentInChildren<RawImage>();
            icon.texture = item.icon;
        }
       
    }
    public void emptySlot() {
        item = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (this.special) { return; };
        GameObject Dropped = eventData.pointerDrag;
        InventoryActions script = Dropped.GetComponent<InventoryActions>();//získá z dropped cestu na instanci a z ní hodlotu dfs
        if (script.DraggedFromSlot == null)//zajištuje aby nedošlo k nullrefferenceexception
        { return;}
        Slotclass ParentSlot = script.DraggedFromSlot.GetComponent<Slotclass>();
        if (ParentSlot == this) { return; }
        if (ParentSlot.item != null)//zajištuje aby nedošlo k nullrefferenceexception pøi pøemisteni slotu do sebe sameho
        {
            if (this.item != null)
            {
                ScriptableItem TemporalyItem = this.item;
                this.item = ParentSlot.item;
                ParentSlot.item = TemporalyItem;
                
            }
            else
            {
                this.item = ParentSlot.item;
                ParentSlot.emptySlot();

            }
            this.SetValues();
            audioManager.PlaySound("pick_item");
        }
    }
    public bool getSpecial()
    {
        return this.special;
    }
  
}


