using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;

    public static UnityAction onFailedRewardAds;
    public static UnityAction onFinalRewardAds;

    [SerializeField] private SkinObject _skinADS;

    [SerializeField] private GameObject AdBlockPanel;
    [SerializeField] private GameObject AdS_ReceivedPanel;
    private int _isShowedAdBlockPanel = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (PlayerPrefs.HasKey("ShowedAdBlockPanel"))
        {
            _isShowedAdBlockPanel = PlayerPrefs.GetInt("ShowedAdBlockPanel");
        }
    }

    private void Start()
    {
        AdS_ReceivedPanel.SetActive(false);
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
    public void AdsRewardedButton(string nameRewarded)
    {
        ShowRewarded(nameRewarded);
    }

    // Показать rewarded video
    public void ShowRewarded(string nameRewarded)
    {
        MainGameSettings.instance.PauseGame();
    }


    // Начался показ
    private void OnRewardedStart()
    {
        MainGameSettings.instance.PauseGame();
        Debug.Log("ON REWARDED: START");
    }
    // Получена награда
    private void OnRewardedReward(string value)
    {
        if (value == "COINS")
        {
            Debug.Log("ON REWARDED: +150 COINS");
            StaticValue.money += 100;
            PlayerPrefs.SetInt("Money", StaticValue.money);
            PlayerPrefs.Save();
            AdS_ReceivedPanel.SetActive(true);
        }

        if (value == "SKIN")
        {
            _skinADS.isBuy = true;
            _skinADS.buttonBuy.gameObject.SetActive(false);
            _skinADS.buttonSelect.gameObject.SetActive(true);
            PlayerPrefs.SetInt("buy" + _skinADS.scinID, 1);
            PlayerPrefs.Save();
            AdS_ReceivedPanel.SetActive(true);
        }
    }

    // Закончился показ
    private void OnRewardedClose(bool success)
    {
        MainGameSettings.instance.UnPauseGame();
        Debug.Log("ON REWARDED: CLOSE");
    }


    // Показать fullscreen
    public void ShowFullscreen()
    {
        if (StaticValue.isFirstEndGame)

        Debug.Log(StaticValue.isFirstEndGame);
    }

    // Начался показ
    private void OnFullscreenStart()
    {
        Debug.Log("ON FULLSCREEN START");
    }

    // Закончился показ
    private void OnFullscreenClose(bool success)
    {
        Debug.Log("ON FULLSCREEN CLOSE");
    }

}
