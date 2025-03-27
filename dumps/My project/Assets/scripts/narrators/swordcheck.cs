using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordcheck : hintSystem
{   private bool dialogend;
    private InventoryManager playersInvetory;
    private State stav;
    private enum State
    {
        nosword,
        sword,
        sharpsword
    }

    private void Awake()
    {
        onLoad();
        dialogend = true;
        playersInvetory = FindObjectOfType<InventoryManager>();
        this.checkInvetory();
    }
    
    protected override void dialogEnded()
    {
        this.dialogend = true;   
    }

    private void show()
    {
        
        this.dialogend = false;

        showHint();
    
    }
    public void inwoke()
    {
        if (dialogend) {
            this.dialogend = false;
   
            this.checkInvetory();
  

        switch (stav)
        {
            case State.nosword: {
                    this.setStage(0, 0, false);
                }break;

            case State.sword:
                {
                    
                    this.setStage(1, 1, false);
                }
                break;
            case State.sharpsword:
                {
                        this.GetComponent<changeScene>().SceneChange();
                        GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>().PlayMusic("boss");
                    return;
                }
                
        }
        
            this.show();
        }
    }
    private void checkInvetory()
    {
        foreach (Slotclass slot in playersInvetory.slots)
        {
            if (slot.item == null) { continue; }
            switch (slot.item.id)
            {
                case 7: { stav = State.sword;return; }
                case 8: { stav = State.sharpsword; return; }
                default:break;

            }
        }
        stav = State.nosword;
    }
}

