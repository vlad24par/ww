using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldSettings", menuName = "Settings/FieldSettings")]
public class FieldSettings : ScriptableObject
{
    public int X;
    public int Y;

    [Space(10)]
    public int HillPercent = 0;
    public int MountainPercent = 0;
    public int ForestPercent = 0;
    public int FieldPercent = 0;
    public int SwampPercent = 0;
}
