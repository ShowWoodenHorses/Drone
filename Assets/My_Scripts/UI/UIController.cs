using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _countEnemy;


    private void OnEnable()
    {
        TargetController.targetAction += AddEnemy;
    }

    private void OnDisable()
    {
        TargetController.targetAction -= AddEnemy;
    }
    void Start()
    {
        
    }

    void Update()
    {
        _text.text = _countEnemy.ToString();
    }

    void AddEnemy()
    {
        _countEnemy++;
    }
}
