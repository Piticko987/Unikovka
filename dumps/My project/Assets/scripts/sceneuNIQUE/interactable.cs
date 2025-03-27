using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    [SerializeField] private bool interac;
    private void Awake()
    {
        GameObject invetory=GameObject.Find("MainCanvas");
        invetory.transform.GetChild(1).gameObject.SetActive(interac);
        invetory.GetComponent<UIKeyOpener>().interactable = interac;
    }
}
