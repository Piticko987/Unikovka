using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Craftingmanager : MonoBehaviour

{
    [SerializeField] public Slotclass[] slot = new Slotclass[3];
    [SerializeField] private Recipe[] recipe;
    [SerializeField] MasterAudioManager audioManager;
    private bool crafted;


    private void Awake()
    {
        crafted = false;
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item == null)
            {
                slot[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                slot[i].SetValues();
            }
        }

    }
    public ScriptableItem checkCraft()
    {
        
        foreach (Recipe recept in recipe)
        {
            if ((slot[0].item == recept.craftFromItem[0]) && (slot[1].item == recept.craftFromItem[1]))//zefektivnit porovnávání
            {
                crafted = true;
                return recept.craftItem;
               
            }
            else
            {
                if ((slot[0].item == recept.craftFromItem[1]) && (slot[1].item == recept.craftFromItem[0]))
                {
                    crafted = true;
                    return recept.craftItem;
                }

            }

        }
        return null;
    }
    public void craft(ScriptableItem craftItem)
    {
        if (slot[2].item == null)
        {
            slot[2].item = craftItem;
            slot[2].SetValues();
            
        }
        setCrafted();
    }
    public void craftPicked()
    {
            if (crafted) { 
            for(int i=0;i<2;i++)
            {
                slot[i].emptySlot();
                slot[i].SetValues();
               
            }
            
            setCrafted();
            
        }
        
    }
    public void craftPickedfromInput()
    {
        if (crafted)
        {
                slot[2].emptySlot();
                slot[2].SetValues();
        }
        setCrafted();
        
    }
   private void setCrafted()
        {
        if (checkCraft() != null)
        {
            if (slot[2].item == checkCraft())
            {
                audioManager.PlaySound("craft");
                return;
            }
        };
        
        crafted = false;
        }
    public void clear()
    {
        for (int i= 0;i<3;i++)
        {
            if (slot[i].item == null) {
                slot[i].emptySlot();
                slot[i].SetValues();
            };
            
                }
    }
}
 
