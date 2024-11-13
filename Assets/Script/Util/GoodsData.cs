using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class GoodsData : MonoBehaviour
{


    public int testGoldAmount;
    private BigInteger gold = 1;
    private BigInteger payGold = 1;

    private string FormatNum(BigInteger num)
    {
        string[] units = { "", "K", "M", "Y", "I" };
        int unitIndex = 0;

        while (num > 1000 && unitIndex < units.Length - 1)
        {

            num /= 1000;
            unitIndex++;

        }

        string fNum = string.Format("{0}{1}", num.ToString(), units[unitIndex]);

            return fNum;
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

        if(CostGold < gold)
        gold -= CostGold;

        return gold;

    }

    public void TestGold()
    {
        gold += testGoldAmount;
    
    }



}