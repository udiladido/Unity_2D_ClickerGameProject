using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class GoodsData 
{


    private BigInteger gold = 0;
    private BigInteger PayGold = 0;
  

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

    

}