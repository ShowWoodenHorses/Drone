using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;
using System;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;

    public static UnityAction onFailedRewardAds;
    public static UnityAction onFinalRewardAds;

    [SerializeField] private GameObject _ADSPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        GP_Ads.OnAdsStart += OnRewardedStart;
        GP_Ads.OnAdsStart += OnFullscreenStart;
        GP_Ads.OnAdsClose += OnRewardedClose;
        GP_Ads.OnAdsClose += OnFullscreenClose;
    }

    private void OnDisable()
    {
        GP_Ads.OnAdsStart -= OnRewardedStart;
        GP_Ads.OnAdsStart -= OnFullscreenStart;
        GP_Ads.OnAdsClose -= OnRewardedClose;
        GP_Ads.OnAdsClose -= OnFullscreenClose;
    }
    public void AdsRewardedButton(string nameRewarded)
    {
        ShowRewarded(nameRewarded);
    }

    // �������� rewarded video
    public void ShowRewarded(string nameRewarded)
    {
        MainGameSettings.instance.PauseGame();
        GP_Ads.ShowRewarded(nameRewarded, OnRewardedReward, OnRewardedStart, OnRewardedClose);
    }


    // ������� �����
    private void OnRewardedStart()
    {
        MainGameSettings.instance.PauseGame();
        Debug.Log("ON REWARDED: START");
    }
    // �������� �������
    private void OnRewardedReward(string value)
    {
        if (value == "COINS")
        {
            Debug.Log("ON REWARDED: +150 COINS");
            StaticValue.money += 100;
            PlayerPrefs.SetInt("Money", StaticValue.money);
            PlayerPrefs.Save();
        }

        if (value == "GEMS")
            Debug.Log("ON REWARDED: +5 GEMS");
    }

    // ���������� �����
    private void OnRewardedClose(bool success)
    {
        MainGameSettings.instance.UnPauseGame();
        Debug.Log("ON REWARDED: CLOSE");
    }


    // �������� fullscreen
    public void ShowFullscreen()
    {
        GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);
    }

    // ������� �����
    private void OnFullscreenStart()
    {
        Debug.Log("ON FULLSCREEN START");
    }

    // ���������� �����
    private void OnFullscreenClose(bool success)
    {
        Debug.Log("ON FULLSCREEN CLOSE");
    }
}
