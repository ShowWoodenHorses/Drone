using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _rotateElementInEnemy;
    [SerializeField] private float _distance;
    [SerializeField] private float _speedRotate;

    [Header("Spawn Bullet")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _effectShot;
    [SerializeField] private Transform _spawnBulletTransform;
    [SerializeField] private float _cooldownTimer;
    [SerializeField] private bool _isCooldown = false;

    private void Start()
    {
        if (_player == null)
            _player = GetComponent<EnemyController>().player;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,
            _player.transform.position) < _distance)
        {
            Attack();

        }
        else
            ReturnStartPosition();
    }

    void Attack()
    {
        Vector3 direction = _player.transform.position - transform.position;
        Quaternion rotate = _rotateElementInEnemy.transform.rotation;
        _rotateElementInEnemy.transform.rotation = Quaternion.RotateTowards(rotate,
            Quaternion.LookRotation(direction), _speedRotate * Time.deltaTime);
        if (!_isCooldown && _rotateElementInEnemy.transform.rotation == Quaternion.LookRotation(direction))
        {
            StartCoroutine(Cooldown());
            StartCoroutine(Shot());
        }
    }

    void ReturnStartPosition()
    {
        Quaternion rotate = _rotateElementInEnemy.transform.localRotation;
        _rotateElementInEnemy.transform.localRotation = Quaternion.RotateTowards(rotate,
            Quaternion.LookRotation(Vector3.zero), _speedRotate * Time.deltaTime);
    }

    private IEnumerator Shot()
    {
        yield return new WaitForSeconds(1f);
        GameObject effectShot = Instantiate(_effectShot, _spawnBulletTransform.position, Quaternion.identity);
        GameObject rocketObj = Instantiate(_bulletPrefab, _spawnBulletTransform.position, Quaternion.identity);
        rocketObj.GetComponent<ICanAttack>().InitializeAttack(_player);
        Destroy(effectShot, 1f);
    }

    private IEnumerator Cooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_cooldownTimer);
        _isCooldown = false;
    }
}
