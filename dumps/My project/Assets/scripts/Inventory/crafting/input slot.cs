using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inputslot : MonoBehaviour, IDropHandler,IEndDragHandler
{ 
    [SerializeField]private Craftingmanager script;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject Dropped = eventData.pointerDrag;
        InventoryActions action = Dropped.GetComponent<InventoryActions>();//získá z dropped cestu na instanci a z ní hodlotu dfs
        if (action.DraggedFromSlot == null)//zajištuje aby nedošlo k nullrefferenceexception
        { return; }
        Slotclass ParentSlot = action.DraggedFromSlot.GetComponent<Slotclass>();

        if (ParentSlot.getSpecial())
        {
            if (ParentSlot.item != null)
            {
                Slotclass slot= this.gameObject.GetComponent<Slotclass>();
                script.clear();
                ParentSlot.item = slot.item;
            }
        }
        else { 
        script.craftPickedfromInput();
        script.craft(script.checkCraft());
    }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        script.craftPickedfromInput();
        script.craft(script.checkCraft());
    }
}
