using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Legacy : Singleton<GameManager_Legacy>
{

    private GoodsData goodsData;

    public GoodsData GoodsData { get { return goodsData; } }

   
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
