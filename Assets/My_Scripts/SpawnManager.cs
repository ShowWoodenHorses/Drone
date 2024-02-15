using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnListPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPointsTransform = new List<Transform>();
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _startTimer;
    [SerializeField] private float _timer;

    private void Start()
    {
        _timer = _startTimer;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _timer = _startTimer;
            Spawner();
        }
    }

    void Spawner()
    {
        int indexPrefabs = Random.Range(0, spawnListPrefabs.Count);
        int indexTransform = Random.Range(0, spawnPointsTransform.Count);
        GameObject obj = Instantiate(spawnListPrefabs[indexPrefabs], 
            spawnPointsTransform[indexTransform].position, Quaternion.identity);
        obj.GetComponent<EnemyController>().Initialize(_target, _player);
        return;
    }
}
