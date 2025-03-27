using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyNarrator : hintSystem
{
    [SerializeField]private changeScene change;
    private MasterAudioManager audioManager;

    private void Awake()
    {
        onLoad();
        this.showHint();
        audioManager = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();
    }

    public void skip()
    {
        audioManager.PlaySound("click");
        StopAllCoroutines();
        if (hints[stage].Length != hintText.text.Length)
        {
          this.hintText.text = hints[this.stage];
            StartCoroutine(deleteText());
        }
        else
        {
            this.hintText.text ="";
            setStage(this.maxStage,this.minStage, true);
        }
        
        
    }
    public void rollback()
    {
        audioManager.PlaySound("click");
        StopAllCoroutines();
        this.hintText.text = "";
        if (this.stage != 0) {   
            this.stage = this.stage - 1;  
        }
        showHint();

    }
    protected override void dialogEnded()
    {
        sleepsimulator sleep = this.GetComponent<sleepsimulator>();
        GameObject.Find("skip").SetActive(false);
        GameObject.Find("rolback").SetActive(false);
        sleep.StopAllCoroutines();
        sleep.StartCoroutine(sleep.blink());
        change.SceneChange();
    }



}
