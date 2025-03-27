using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outroNarrator : hintSystem
{
 
    [SerializeField] private GameObject exit, restart;

    private void Awake()
    {
        onLoad();
        this.showHint();
    }
    protected override void dialogEnded()
    {
        Destroy(this.hintText);
        this.exit.SetActive(true);
        this.restart.SetActive(true);
        checkInvetory();
    }
    private void checkInvetory()
    {
        InventoryManager invet = FindAnyObjectByType<InventoryManager>();
        foreach (Slotclass slot in invet.slots)
        {
            slot.item = null;
            slot.SetValues();
        }
    }

}
