using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinObject : MonoBehaviour
{
    public int cost; // стоимость скина
    public int scinID; // id скина. куплен ли скин?
    public bool isBuy; // куплен ли скин?
    public bool isSelected; // активирован ли скин?

    int money;

    public Button buttonBuy; // ссылка на кнопку "купить"
    public Button buttonSelect; // ссылка на кнопку "применить"
    public SkinShopObject skinShop; // ссылка на скрипт ScinShop магазина, который находится на объекте Canvas


    private void Start()
    {
        money = StaticValue.money;
    }
    public void Buy()
    {
        Debug.Log("Buy");
        if (StaticValue.money >= cost)
        {
            Debug.Log("Money");
            StaticValue.money -= cost;
            isBuy = true;
            buttonBuy.gameObject.SetActive(false);
            buttonSelect.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Money", StaticValue.money);
            PlayerPrefs.SetInt("buy" + scinID, 1);
            PlayerPrefs.Save();
        }
    }

    public void Select()
    {
        skinShop.skins[skinShop.activeScinID].buttonSelect.gameObject.SetActive(true);
        skinShop.skins[skinShop.activeScinID].isSelected = false;
        skinShop.activeScinID = scinID;
        isSelected = true;
        buttonSelect.gameObject.SetActive(false);
        PlayerPrefs.SetInt(skinShop.nameSkin, scinID);
        PlayerPrefs.Save();
    }
}
