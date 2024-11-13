using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "ClickEvent")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public Sprite itemSprite;

    [Header("Level Data")]
    public float[] UpgradeCost;
    public float[] EarnMoney;
    public float [] CoolTime;



}
