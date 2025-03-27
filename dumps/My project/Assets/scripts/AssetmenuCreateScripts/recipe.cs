using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Scriptable Items/recipes", menuName = "create new Recipe")]
public class Recipe : ScriptableObject
{
    public ScriptableItem[] craftFromItem =new ScriptableItem[2];
    public ScriptableItem craftItem;
}
