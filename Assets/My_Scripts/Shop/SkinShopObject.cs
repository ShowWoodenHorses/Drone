using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinShopObject : MonoBehaviour
{
    public int money; // ���������� ����� ����� ��� ������ ����
    public TextMeshProUGUI textMoney; // ������ �� ����� �� ������� �����, � ������� ���������� ���������� �����.
    public SkinObject[] skins; // ������ �� ��� ���� ����� (������� Scin1, Scin2, Scin3)
    public int activeScinID = 0; // ����� �����, ������� ������ � ����������� ����������
    public string nameSkin;

    private void Start()
    {
        if (PlayerPrefs.HasKey(nameSkin))
        {
            activeScinID = PlayerPrefs.GetInt(nameSkin);
        }
        skins[activeScinID].isBuy = true;
        skins[activeScinID].isSelected = true;
        PlayerPrefs.SetInt("buy" + activeScinID, 1);
        PlayerPrefs.SetInt(nameSkin, activeScinID);
        PlayerPrefs.Save();

        for (int j = 0; j < skins.Length; j++)
        {

            if (PlayerPrefs.GetInt("buy" + j) == 1)
            {
                skins[j].isBuy = true;
            }

            if (skins[j].isBuy == true)
            {
                skins[j].buttonBuy.gameObject.SetActive(false);
            }

            if (skins[j].isSelected == true || skins[j].isBuy == false)
            {
                skins[j].buttonSelect.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        textMoney.text = StaticValue.money.ToString();

    }
}
