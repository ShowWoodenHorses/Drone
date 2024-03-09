
using UnityEngine;

public class CheckNearbyEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _effectShowEnemy;
    [SerializeField] private GameObject _obj;
    private float _startTimer = 2f;
    private float _timer;
    public bool isActive = false;
    private void Start()
    {
        _obj = Instantiate(_effectShowEnemy, transform.position, Quaternion.identity);
        _obj.SetActive(false);
        _timer = _startTimer;
    }
    private void Update()
    {
        _obj.SetActive(false);
        if (isActive)
        {
            _obj.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            _obj.transform.Rotate(transform.rotation.x, transform.rotation.y +2f *Time.deltaTime, transform.rotation.z);
            _obj.SetActive(true);
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                isActive = false;
                _timer = _startTimer;
            }
        }
    }
    public void ShowEnemy()
    {
        isActive = true;
    }
}
