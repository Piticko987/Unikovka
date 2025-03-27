using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiHover : MonoBehaviour
{
    private GameObject hl;
    private GameObject hover;
    private bool hoverable;
    public bool editHover;

    private void Awake()
    {
        hover = this.transform.GetChild(1).gameObject;//získá objekt potomka tohoto objektu (hover image)
        hl = this.transform.GetChild(0).gameObject;
        hoverable = true;
    }

    public void OnMouseOver()
    {
        if (hoverable)
        {
            hover.SetActive(false);
            hl.SetActive(true);
        }
    }
    public void OnMouseExit()
    {
        if (hoverable)
        {
            hover.SetActive(true);
            hl.SetActive(false);
        }
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
    public void setEditHover(bool edit)
    {
        this.editHover = edit;
    }
}