using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinShop : MonoBehaviour
{
    public int money; // количество ваших денег при старте игры
    public TextMeshProUGUI textMoney; // ссылка на текст на игровой сцене, в котором отображено количество денег.
    public Skin[] skins; // ссылки на все ваши скины (объекты Scin1, Scin2, Scin3)
    public int activeScinID = 0; // номер скина, который куплен и активирован изначально

    private void Start()
    {

        if (PlayerPrefs.HasKey("CountKillAll"))
        {
            money = PlayerPrefs.GetInt("CountKillAll");
        }

        if (PlayerPrefs.HasKey("scinsID"))
        {
            activeScinID = PlayerPrefs.GetInt("scinsID");
        }
        skins[activeScinID].isBuy = true;
        skins[activeScinID].isSelected = true;
        PlayerPrefs.SetInt("buy" + activeScinID, 1);
        PlayerPrefs.SetInt("scinsID", activeScinID);
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
        textMoney.text = money.ToString();

    }
}