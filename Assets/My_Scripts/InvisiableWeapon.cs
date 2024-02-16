
using UnityEngine;

public class InvisiableWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _weaponObj;
    [SerializeField] private float _startTimer;
    private float _timer;
    private float _timerWeapon;

    private void Start()
    {
        _timer = _startTimer;
        _timerWeapon = _startTimer;
        _weaponObj.SetActive(false);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _timerWeapon -= Time.deltaTime;
            _weaponObj.SetActive(true);
            if (_timerWeapon <= 0)
            {
                _timer = _startTimer;
                _timerWeapon = _startTimer;
            }
        }
        else
            _weaponObj.SetActive(false);
    }
}
