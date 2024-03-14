using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnListPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPointsTransform = new List<Transform>();
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private List<GameObject> _targetsObj = new List<GameObject>();
    [SerializeField] private GameObject _player;
    [SerializeField] private float _startTimer;
    [SerializeField] private float _timer;

    [SerializeField] private GameObject ArrowDirectionObj;
    private ArrowDrection _arrowDirection;

    private void Start()
    {
        _arrowDirection = ArrowDirectionObj.GetComponent<ArrowDrection>();
        _timer = _startTimer;
    }

    private void Update()
    {
        //_timer -= Time.deltaTime;
        //if (_timer < 0)
        //{
        //    _timer = _startTimer;
        //    Spawner();
        //}
    }

    public void Spawner()
    {
        int indexPrefabs = Random.Range(0, spawnListPrefabs.Count);
        int indexTransform = Random.Range(0, spawnPointsTransform.Count);
        int indexTarget = Random.Range(0, _targetsObj.Count);
        GameObject obj = Instantiate(spawnListPrefabs[indexPrefabs], 
            spawnPointsTransform[indexTransform].position, Quaternion.identity);
        if (ArrowDirectionObj.activeInHierarchy == true)
            obj.GetComponent<EnemyController>().Initialize(_targetsObj[indexTarget], _player, _arrowDirection);
        else
            obj.GetComponent<EnemyController>().Initialize(_targetsObj[indexTarget], _player);

        return;
    }
}
