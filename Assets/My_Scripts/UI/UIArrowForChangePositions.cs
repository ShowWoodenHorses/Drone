using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowForChangePositions : MonoBehaviour
{

    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _objArrowLeft;
    [SerializeField] private GameObject _objArrowRight;
    [SerializeField] private int _index = 0;


    void Start()
    {
        foreach (GameObject obj in _objects)
        {
            obj.SetActive(false);
        }
        _objects[_index].SetActive(true);
    }

    private void Update()
    {
        if (_index == 0)
            _objArrowLeft.SetActive(false);
        else
        {
            _objArrowLeft.SetActive(true);
        }
        if (_index == _objects.Length - 1)
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
        _objects[_index + 1].SetActive(false);
        _objects[_index].SetActive(true);
    }

    public void ArrowRight()
    {
        _index++;
        if (_index >= _objects.Length)
        {
            _index = _objects.Length - 1;
        }
        _objects[_index - 1].SetActive(false);
        _objects[_index].SetActive(true);
    }
}
