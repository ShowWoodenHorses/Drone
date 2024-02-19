using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public int cost; // ��������� �����
    public int scinID; // id �����. ������ �� ����?
    public bool isBuy; // ������ �� ����?
    public bool isSelected; // ����������� �� ����?

    int _countKill;

    public Button buttonBuy; // ������ �� ������ "������"
    public Button buttonSelect; // ������ �� ������ "���������"
    public SkinShop skinShop; // ������ �� ������ ScinShop ��������, ������� ��������� �� ������� Canvas


    private void Start()
    {
        _countKill = PlayerPrefs.GetInt("CountKillAll");
    }
    public void Buy()
    {
        if (_countKill >= cost)
        {
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
        PlayerPrefs.SetInt("scinsID", scinID);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        skinShop.textMoney.text = PlayerPrefs.GetInt("CountKillAll").ToString();
    }
}
