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


    // 문자열을 바로 포맷팅
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
        return "0"; // 파싱 실패시 기본값
    }

    public string stringGold(string numster)
    {
       return FormatNumString(numster);

    }

}
