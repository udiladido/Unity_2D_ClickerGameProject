using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class GoodsData : MonoBehaviour
{


    public int testGoldAmount;
    private BigInteger gold = 1;
    private BigInteger payGold = 1;

    string[] units = { "", "K", "M", "Y", "I" };

    private string FormatNum(BigInteger num)
    {
  
        int unitIndex = 0;

        while (num > 1000 && unitIndex < units.Length - 1)
        {

            num /= 1000;
            unitIndex++;

        }

        string fNum = string.Format("{0}{1}", num.ToString(), units[unitIndex]);

            return fNum;
    }


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

    public string stringGold()
    {
        return FormatNum(gold);
    
    }

    public string stringPayGold()
    {

        return FormatNum(gold);

    }

    public BigInteger GetGold(BigInteger dropGold)
    {

        gold += dropGold;

        return gold;
   
    }

    public BigInteger PayGold(BigInteger CostGold)
    {

        gold -= CostGold;

        return gold;

    }

    public bool HasEnough(BigInteger CostGold)
    {

        if (gold > CostGold)
            return true;

        return false;

    }


    public void TestGold()
    {
        gold += testGoldAmount;
    
    }



}