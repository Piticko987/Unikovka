using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public Slotclass[] slots = new Slotclass[36];
   
    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null)
            {
              slots[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else {
            slots[i].SetValues();
            }
        }
       
    }
    public void PickupItem(Itemclass itemObject)
    {
        PickupScriptableItem(itemObject.item);
        Destroy(itemObject.gameObject);
    }

    public void PickupScriptableItem(ScriptableItem item)
    {
        
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].item = item;
                    slots[i].SetValues();
                    break;
                }

            }
        
    }
    public void ShowItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                  slots[i].SetValues();
            }
        }


    }


}
