using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mRunesScript : MonoBehaviour
{
    [SerializeField] Image butTop;
    [SerializeField] Image butMid;
    [SerializeField] Image butBot;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private ScriptableItem[] itemsrm;
    [SerializeField] private float[] rmx;
    [SerializeField] private float[] rmy;
    [SerializeField] private ScriptableItem[] items;
    [SerializeField] private float[] x;
    [SerializeField] private float[] y;
    GameObject gg;
    public void TopPressed()
    {
        if (butTop.sprite == sprites[5]) {
            butTop.sprite = sprites[0]; 
        
        }
        else
        {
            Sprite ac = butTop.sprite;
            int ko = System.Array.IndexOf(sprites, ac);
            int ne = ko + 1;
            butTop.sprite = sprites[ne];
        }
 
    }
    public void MidPressed()
    {
        if (butMid.sprite == sprites[5])
        {
            butMid.sprite = sprites[0];
    
        }
        else
        {
            Sprite ac = butMid.sprite;
            int ko = System.Array.IndexOf(sprites, ac);
            int ne = ko + 1;
            butMid.sprite = sprites[ne];
        }
    
    }
    public void BotPressed()
    {
        if (butBot.sprite == sprites[5])
        {
            butBot.sprite = sprites[0];

        }
        else
        {
            Sprite ac = butBot.sprite;
            int ko = System.Array.IndexOf(sprites, ac);
            int ne = ko + 1;
            butBot.sprite = sprites[ne];
        }
      
    }

    public void isRight()
    {
        if (butTop.sprite == sprites[4] && butMid.sprite == sprites[5] && butBot.sprite == sprites[0]) {
            gg.SetActive(true);
            GameObject.Find("saver").GetComponent<minigaeExit>().change(items, x, y, itemsrm, rmx, rmy);
            SceneManager.LoadScene(3);
        }
        else Debug.Log("Zle");
    }
    private void Start()
    {
        butTop.sprite = sprites[0];
        butMid.sprite = sprites[0];
        butBot.sprite = sprites[0];
        //Sprite ac = butTop.sprite;
        //int ko = System.Array.IndexOf(sprites,ac);
        //Debug.Log(ko);
    }
    private void Awake()
    {
        gg = GameObject.Find("movement");
        gg.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
    }
}
