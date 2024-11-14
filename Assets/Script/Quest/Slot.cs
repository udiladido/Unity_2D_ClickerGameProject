using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Numerics;
using System.Linq;

public class Slot : MonoBehaviour
{
    public ItemData data;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text upgradeCost;
    [SerializeField] TMP_Text earnMoney;
    [SerializeField] Button upgradeButton;
    [SerializeField] Button getMoneyButton;
    [SerializeField] Image cooldownImage;

    [SerializeField] private int upgradeLevel = 0;


    private BigInteger upgradeAmount;
    private BigInteger earnMoneyAmount;

    private bool isCoolTime = false;
    private float coolTime;
 


    private void Awake()
    {

        //현재 씬이 바뀌는 경우 문제 발생 가능성

        icon = GetComponentsInChildren<Image>()[0];
        cooldownImage = GetComponentsInChildren<Image>()[2];
        TMP_Text[] text = GetComponentsInChildren<TMP_Text>();
        Button[] button = GetComponentsInChildren<Button>();

        upgradeCost = text[0];
        earnMoney = text[1];
        upgradeButton = button[0];
        getMoneyButton = button[1];

        Init();
    }

    private void Init()
    {
        icon.sprite = data.itemSprite;
        upgradeCost.text = data.stringGold(data.UpgradeCost[0]);
        earnMoney.text = data.stringGold(data.EarnMoney[0]);

        coolTime = data.CoolTime[0];

        upgradeAmount = BigInteger.Parse(data.UpgradeCost[0]);
        earnMoneyAmount = BigInteger.Parse(data.EarnMoney[0]);

        upgradeButton.onClick.AddListener(Upgrade);
        getMoneyButton.onClick.AddListener(QuestDone);

    }


    private void Upgrade()
    {

        if (GameManager_Legacy.Instance.GoodsData.HasEnough(upgradeAmount)) 
        {
        
            upgradeLevel++;

            if (upgradeLevel < data.maxUpgrade)
            {

                GameManager_Legacy.Instance.GoodsData.PayGold(upgradeAmount);
                upgradeCost.text = data.stringGold(data.UpgradeCost[upgradeLevel]);
                earnMoney.text = data.stringGold(data.EarnMoney[upgradeLevel]);

                upgradeAmount = BigInteger.Parse(data.UpgradeCost[upgradeLevel]);
                earnMoneyAmount = BigInteger.Parse(data.EarnMoney[upgradeLevel]);

                UpdateUI();

            }
            else
            {
                upgradeLevel = data.maxUpgrade - 1;
                upgradeButton.onClick.RemoveListener(Upgrade);
            }
                
        }

    }

    private void UpdateUI()
    {

        GameManager_Legacy.Instance.textGold.text = GameManager_Legacy.Instance.GoodsData.stringGold();


    }


    private void QuestDone()
    {
        if (!isCoolTime)
        {
            GameManager_Legacy.Instance.GoodsData.GetGold(earnMoneyAmount);
            UpdateUI();
            // cooldownImage를 직접 전달
            CooldownManager.Instance.StartCooldown(this, data.CoolTime[upgradeLevel], cooldownImage);
            isCoolTime = true;
        }
    }

    public void SetCooldownComplete()
    {
        isCoolTime = false;
    }

}
