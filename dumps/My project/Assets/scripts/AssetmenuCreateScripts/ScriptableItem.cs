using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Scriptable Items",menuName = "create new item")]
public class ScriptableItem : ScriptableObject
{
    public int id;
    public Texture icon;
    public string path;
}
