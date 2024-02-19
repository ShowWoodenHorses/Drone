
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyFromEnemy : MonoBehaviour
{
    [SerializeField] private float _startSpawnTimer;
    private float _spawnTimer;
    [SerializeField] private int _countEnemyForSpawn;
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private List<Transform> _spawnsPos = new List<Transform>();

    private EnemyController _enemyController;

    private void Start()
    {
        _spawnTimer = _startSpawnTimer;
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0 &&  _countEnemyForSpawn > 0)
        {
            _spawnTimer = _startSpawnTimer;
            _countEnemyForSpawn--;
            GameObject enemy = Instantiate(_spawnPrefab, 
                _spawnsPos[Random.Range(0, _spawnsPos.Count)].position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().Initialize(_enemyController.SetTargetObj());

        }
    }
}
