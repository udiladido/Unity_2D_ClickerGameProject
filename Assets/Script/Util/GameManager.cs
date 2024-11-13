using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    private GoodsData goodsData;

    [Header("UI")]
    public TMP_Text textGold;


    public void Start()
    {
        goodsData = GetComponent<GoodsData>();
        textGold.text = goodsData.stringGold();
    }




    public void SumGoldTest()
    { 

        goodsData.TestGold();
        textGold.text = goodsData.stringGold();
    }

}
