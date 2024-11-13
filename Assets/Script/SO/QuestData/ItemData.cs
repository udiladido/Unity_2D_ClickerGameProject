using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


[CreateAssetMenu(fileName = "Slot", menuName = "ClickEvent")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public Sprite itemSprite;

    [Header("Level Data")]
    public string[] UpgradeCost;
    public string[] EarnMoney;
    public float [] CoolTime;

    public int maxUpgrade;



    string[] units = { "", "K", "M", "Y", "I" };


    // ���ڿ��� �ٷ� ������
    private string FormatNumString(string numStr)
    {
        if (BigInteger.TryParse(numStr, out BigInteger num))
        {
            int unitIndex = 0;
            BigInteger divisor = 1000;

            while (num >= divisor && unitIndex < units.Length - 1)
            {
                num /= divisor;
                unitIndex++;
            }

            return $"{num}{units[unitIndex]}";
        }
        return "0"; // �Ľ� ���н� �⺻��
    }

    public string stringGold(string numster)
    {
       return FormatNumString(numster);

    }

}
