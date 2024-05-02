using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _effectExplotion;
    [SerializeField] private GameObject _startEffecr;

    private void Start()
    {
        _startEffecr.SetActive(true);
        Destroy(_startEffecr, 1f);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<EnemyController>())
        {
            _effectExplotion.SetActive(true);
            other.transform.GetComponent<EnemyController>().TakeDamage(_damage);
            Destroy(gameObject,1f);
        }
    }  
}
