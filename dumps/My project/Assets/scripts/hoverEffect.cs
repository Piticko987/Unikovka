using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverEffect : MonoBehaviour
{
    private GameObject hover;
    private bool hoverable;
    public bool editHover;
   
    private void Awake()
    {
        hover = this.transform.GetChild(0).gameObject;//získá objekt potomka tohoto objektu (hover image)
        hoverable = true;
    }

    public void OnMouseOver()
    {
        this.HoverStart();
    }
    public void OnMouseExit()
    {
        this.HoverEnd();  
    }
    public void OnMouseUp()
    {
        
            hoverable = true;
    }
    public void OnMouseDown()
    {
        if (editHover)
        {
            hoverable = false;
        }
    }
    public void HoverStart() {
        if (hoverable)
        {
            hover.SetActive(true);
        }
    }
    public void HoverEnd()
    {
        if (hoverable)
        {
            hover.SetActive(false);
        }
    }
    public void setEditHover(bool edit)
    {
        this.editHover = edit;
    }
}
