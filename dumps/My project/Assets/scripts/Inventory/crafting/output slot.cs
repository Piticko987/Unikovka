using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class outputslot : MonoBehaviour, IEndDragHandler,IDropHandler
{
    [SerializeField] private Craftingmanager script;

    public void OnDrop(PointerEventData eventData)
    {
        script.craftPicked();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        script.craftPicked();
        Debug.Log("endDrag");
    }

}
