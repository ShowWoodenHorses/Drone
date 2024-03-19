using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowForChangePositions : MonoBehaviour
{

    [SerializeField] private GameObject[] _showDroneInShop;
    [SerializeField] private GameObject[] _hideDroneInShop;
    [SerializeField] private GameObject[] _objectsDronesForBuy;
    [SerializeField] private GameObject _objArrowLeft;
    [SerializeField] private GameObject _objArrowRight;
    [SerializeField] private int _index = 0;


    void Start()
    {
        foreach (GameObject obj in _objectsDronesForBuy)
        {
            obj.SetActive(false);
        }
        _objectsDronesForBuy[_index].SetActive(true);
    }

    private void Update()
    {
        if (_index == 0)
            _objArrowLeft.SetActive(false);
        else
        {
            _objArrowLeft.SetActive(true);
        }
        if (_index == _objectsDronesForBuy.Length - 1)
            _objArrowRight.SetActive(false);
        else
        {
            _objArrowRight.SetActive(true);
        }
    }

    public void ArrowLeft()
    {
        _index--;
        if (_index <= 0)
        {
            _index = 0;
        }
        _objectsDronesForBuy[_index + 1].SetActive(false);
        _showDroneInShop[_index + 1].SetActive(false);
        _hideDroneInShop[_index + 1].SetActive(true);
        _objectsDronesForBuy[_index].SetActive(true);
        _showDroneInShop[_index].SetActive(true);
        _hideDroneInShop[_index].SetActive(false);
    }

    public void ArrowRight()
    {
        _index++;
        if (_index >= _objectsDronesForBuy.Length)
        {
            _index = _objectsDronesForBuy.Length - 1;
        }
        _objectsDronesForBuy[_index - 1].SetActive(false);
        _showDroneInShop[_index - 1].SetActive(false);
        _hideDroneInShop[_index - 1].SetActive(true);
        _objectsDronesForBuy[_index].SetActive(true);
        _showDroneInShop[_index].SetActive(true);
        _hideDroneInShop[_index].SetActive(false);
    }
}
