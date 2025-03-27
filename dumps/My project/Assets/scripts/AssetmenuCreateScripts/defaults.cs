using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable defaults", menuName = "create new default")]
public class ItemDefaults : ScriptableObject
{
    public String[] items;
    public float[] x;
    public float[] y;
}