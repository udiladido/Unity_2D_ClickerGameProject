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


    private BigInteger upgradeAmount;
    private BigInteger earnMoneyAmount;

    private bool isCoolTime = false;
    private float cooltime;

    private void Awake()
    {

        //현재 씬이 바뀌는 경우 문제 발생 가능성


        icon = GetComponentsInChildren<Image>()[0];
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
        upgradeCost.text = data.UpgradeCost[0].ToString();
        earnMoney.text = data.EarnMoney[0].ToString();
        cooltime = data.CoolTime[0];

        getMoneyButton.onClick.AddListener(Upgrade);
        getMoneyButton.onClick.AddListener(QuestDone);

    }


    private void Upgrade()
    {
        GameManager.Instance.GoodsData.PayGold(upgradeAmount);
        UpdateUI();


    }

    private void UpdateUI()
    {

        GameManager.Instance.textGold.text = GameManager.Instance.GoodsData.stringGold();

    }


    private void QuestDone()
    {

        // 쿨타임이 다 돌면 클릭 시 획득
        if (!isCoolTime)
        {
            GameManager.Instance.GoodsData.GetGold(earnMoneyAmount);
            UpdateUI();

            StartCoroutine(AutoClickCoroutine());

        }
    
    
    }

    private IEnumerator AutoClickCoroutine()
    {

        yield return null;


           
        yield return new WaitForSeconds(cooltime);
        isCoolTime = false;

    }

}
