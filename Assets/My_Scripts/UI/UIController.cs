using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using GamePush;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCountKillEnemy;
    [SerializeField] private int _countKillEnemy;

    [Header("Health Bar")]
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _effectTakeDamage;

    [Header("Count Bomb")]
    [SerializeField] private TextMeshProUGUI _textCountBomb;
    [SerializeField] private DropBomb _dropBomb;

    [Header("Lose Panel")]
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject FailedRewardPanel;
    [SerializeField] private int _moneyForGame;
    [SerializeField] private int _money;
    [SerializeField] private TextMeshProUGUI _textMoneyForGame;
    [SerializeField] private TextMeshProUGUI _textMoney;

    [SerializeField] private GameObject TutorPanel;

    private void OnEnable()
    {
        TargetController.targetAction += EnemyWithZoneTarget;
        EnemyController.onDieEnemy += AddKilledEnemy;
        AdsManager.onFailedRewardAds += ShowPanelFailedReward;
    }

    private void OnDisable()
    {
        TargetController.targetAction -= EnemyWithZoneTarget;
        EnemyController.onDieEnemy -= AddKilledEnemy;
        AdsManager.onFailedRewardAds -= ShowPanelFailedReward;
    }
    void Start()
    {
        MainGameSettings.instance.UnPauseGame();
        _moneyForGame = 0;
        LosePanel.SetActive(false);
        FailedRewardPanel.SetActive(false);
        _health = _maxHealth;
        _sliderHealth.value = _health;
        _sliderHealth.maxValue = _maxHealth;
        TutorPanel.SetActive(true);
        GP_Game.GameplayStart();
    }

    void Update()
    {
        if (LosePanel.activeInHierarchy)
        {
            _textMoney.text = StaticValue.money.ToString();
            _textMoneyForGame.text = _moneyForGame.ToString();
        }
        _sliderHealth.value = _health;
        _textCountKillEnemy.text = _countKillEnemy.ToString();
        _textCountBomb.text = _dropBomb.countBomb.ToString();
    }

    void EnemyWithZoneTarget()
    {
        _health -= UnityEngine.Random.Range(1, 3);
        if (!_effectTakeDamage.activeInHierarchy)
            StartCoroutine(ShowEffectTakeDamage());
        if (_health <= 0)
            GameOver();
    }

    void AddKilledEnemy()
    {
        _countKillEnemy++;
    }

    private IEnumerator ShowEffectTakeDamage()
    {
        _effectTakeDamage.SetActive(true);
        yield return new WaitForSeconds(1f);
        _effectTakeDamage.SetActive(false);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        _moneyForGame += Convert.ToInt32(_countKillEnemy * 2.5f);
        LosePanel.SetActive(true);
        StaticValue.money += _moneyForGame;
        StaticValue.isFirstEndGame = true;
        PlayerPrefs.SetInt("Money", StaticValue.money);
        PlayerPrefs.Save();
        GP_Game.GameplayStop();
    }

    public void ShowPanelFailedReward()
    {
        FailedRewardPanel.SetActive(true);
    }
}
