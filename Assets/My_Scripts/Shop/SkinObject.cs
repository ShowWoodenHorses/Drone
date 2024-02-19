using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinObject : MonoBehaviour
{
    public int cost; // ��������� �����
    public int scinID; // id �����. ������ �� ����?
    public bool isBuy; // ������ �� ����?
    public bool isSelected; // ����������� �� ����?

    int _countKill = 200;

    public Button buttonBuy; // ������ �� ������ "������"
    public Button buttonSelect; // ������ �� ������ "���������"
    public SkinShopObject skinShop; // ������ �� ������ ScinShop ��������, ������� ��������� �� ������� Canvas


    private void Start()
    {
        //_countKill = PlayerPrefs.GetInt("CountKillAll");
    }
    public void Buy()
    {
        Debug.Log("Buy");
        if (_countKill >= cost)
        {
            Debug.Log("_countKill");
            _countKill -= cost;
            isBuy = true;
            buttonBuy.gameObject.SetActive(false);
            buttonSelect.gameObject.SetActive(true);
            PlayerPrefs.SetInt("CountKillAll", _countKill);
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
