using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "SkinSettingsSO")]
public class SkinSettingsSO : ScriptableObject
{
    public int mass;
    public byte maxCountBomb;
    public int maxHeight;
}
