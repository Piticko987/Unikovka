using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public abstract class hintSystem : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI hintText;
    protected string[] hints;
    [SerializeField]protected string hintTextName;
    [SerializeField]protected int maxStage;
    protected int minStage, stage;
   
    
    protected void onLoad()
    {
       string path = Application.dataPath + "/textAssets/" + hintTextName + ".txt";
    hints = File.ReadAllLines(path);
        minStage = 0;
        stage = 0; 
    }



    public void showHint()
    {
        StartCoroutine(animatedText());
    }


    public void setStage(int maxStage,int minStage,bool show)
    {
        if (maxStage > this.stage)
        {
            if (this.stage < minStage)
            {
                this.stage = minStage;
            }
            else {
            this.stage++;
            }
            this.maxStage = maxStage;
            this.minStage = minStage;
            if (show)
            {
                this.showHint();
            }
        }
        else
        {
            if (this.maxStage == this.stage) {
                dialogEnded();
                this.stage = this.minStage;
        }
        }
    }
  
    protected IEnumerator animatedText()
    {
        
        foreach (char znak in hints[stage].ToCharArray())
        {
            yield return new WaitForSeconds(0.075f);
            hintText.text += znak;

        }
        StartCoroutine(deleteText());

    }

    protected IEnumerator deleteText()
    {
        yield return new WaitForSeconds(2);
        hintText.text = "";
        setStage(this.maxStage,this.minStage, true);
    }
    protected abstract void dialogEnded();
    
    
    

    
}
