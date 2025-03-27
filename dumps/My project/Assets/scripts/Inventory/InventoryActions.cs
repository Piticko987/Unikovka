using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryActions : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Slotclass DraggedFromSlot;
    public Transform DraggedParent;
    public Transform Draggeditem;
    private bool dragginItem;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.GetComponent<Slotclass>().item != null)
        {
            DraggedFromSlot = this.GetComponent<Slotclass>();
            DraggedParent = this.transform;
            Draggeditem = DraggedParent.GetComponentInChildren<RawImage>().transform;
            Draggeditem.SetParent(GameObject.Find("MainCanvas").transform);
            
        
            dragginItem = true; 
               
        }
        else {
           
            dragginItem = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragginItem)
        {
            Draggeditem.position = Input.mousePosition;
          Draggeditem.GetComponent<RawImage>().raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragginItem)
        {
            //Draggeditem.parent = DraggedParent;
            Draggeditem.SetParent(DraggedParent);
            Draggeditem.localPosition = new Vector3(0, 0, 0);//zajištuje aby se image navratila do stredu slotu
            Draggeditem.GetComponent<RawImage>().raycastTarget = true;
            DraggedFromSlot.SetValues();//nastaví value slotu
            Draggeditem = null;
            DraggedParent = null;
        }
        dragginItem = false;
     
    }
   
}
