using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIKeyOpener : MonoBehaviour
{
    private bool opened;
    private GameObject invetory;
    private GameObject movement;
    private GameObject menu;
    public bool interactable;

    void Awake()
    {
        opened = false;
        invetory = this.transform.GetChild(0).gameObject;
        movement = this.transform.GetChild(1).gameObject;
        menu = this.transform.GetChild(2).gameObject;
        interactable = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            menuchange();

        }


        if (interactable)
        {
            if (Input.GetKeyDown("i"))
            {
                if (!menu.activeSelf)
                {

                    opened = !opened;
                    invetory.SetActive(this.opened);
                    movement.SetActive(!this.opened);

                }
            }
        }
        else
        {
            this.invetory.SetActive(false); this.opened = false;
        }

       
    }
    public void menuchange()
    {
        invetory.SetActive(menu.activeSelf&&opened);
        movement.SetActive(menu.activeSelf&&interactable);
        menu.SetActive(!menu.activeSelf);
        Time.timeScale = menu.activeSelf ? 0 : 1;
    }
   
}
