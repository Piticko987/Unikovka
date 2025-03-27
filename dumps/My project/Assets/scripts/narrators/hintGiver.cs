using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintGiver : hintSystem
{
    private bool dialogend=false;
    private int max, min;

    private void Awake()
    {
        max = min = 0;
        onLoad();
        StartCoroutine(runDialog());
    }

    void Update()
    {
        if (dialogend)
        {
            if (Input.GetKeyDown("h"))
            {
                this.showHint();
                dialogend = false;
            }
        }
    }
    protected override void dialogEnded()
    {
        dialogend = true;
        if (this.max >stage)
        {
            this.setStage(this.max, this.min, false);
        }
    }

    public void setNextHint(int max, int min)
    {
        if (max > this.max) { 
        this.min = min;
        this.max = max;
    }
        if (dialogend)
        {
            this.setStage(max, min, false);
        }
               

    }

    private IEnumerator runDialog()
    {
        yield return new WaitForSeconds(3);
        showHint();
    }
}
