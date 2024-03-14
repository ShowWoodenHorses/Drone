using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralSpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManagerEartch;
    [SerializeField] private SpawnManager spawnManagerWater;

    public List<SpawnManager> spawnerList = new List<SpawnManager>();

    [SerializeField] private float _timeBetweenWave;
    [SerializeField] private float _timeBetweenSpawnEnemy;
    [SerializeField] private float _startTimeBetweenSpawnEnemy;

    [SerializeField] private int _countWave;
    [SerializeField] private int _currentWave = 0;
    [SerializeField] private int _countEnemyWithOneWave;

    [SerializeField] private GameObject TimerToNextWaveObj;
    [SerializeField] private TextMeshProUGUI _textTimerToNextWave;

    //Arraies
    [SerializeField] private List<int> countEnemyWithOneWaveList = new List<int>();
    [SerializeField] private List<float> timeBetweenWaveList = new List<float>();
    [SerializeField] private List<float> startTimeBetweenSpawnEnemyList = new List<float>();


    private void Start()
    {
        _timeBetweenSpawnEnemy = _startTimeBetweenSpawnEnemy;
        ChangeValve();
    }

    private void Update()
    {
        _textTimerToNextWave.text = Mathf.Round(_timeBetweenWave).ToString();
        _timeBetweenWave -= Time.deltaTime;
        if (_timeBetweenWave < 0)
        {
            TimerToNextWaveObj.SetActive(false);
            _timeBetweenSpawnEnemy -= Time.deltaTime;
            if (_timeBetweenSpawnEnemy < 0 && _countEnemyWithOneWave > 0)
            {
                spawnerList[Random.Range(0, spawnerList.Count)].Spawner();
                _timeBetweenSpawnEnemy = _startTimeBetweenSpawnEnemy;
                _countEnemyWithOneWave--;
            }
            else if (_countEnemyWithOneWave == 0 && _currentWave != _countWave)
            {
                _currentWave++;
                ChangeValve();
                TimerToNextWaveObj.SetActive(true);
            }
            else if(_currentWave == _countWave)
            {
                _currentWave = 0;
            }
        }
    }

    private void ChangeValve()
    {
        switch (_currentWave)
        {
            case 0:
                _timeBetweenWave = timeBetweenWaveList[0];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[0];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[0];
                break;
            case 1:
                _timeBetweenWave = timeBetweenWaveList[1];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[1];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[1];
                break;
            case 2:
                _timeBetweenWave = timeBetweenWaveList[2];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[2];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[2];
                spawnerList.Add(spawnManagerWater);
                break;
            case 3:
                _timeBetweenWave = timeBetweenWaveList[3];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[3];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[3];
                break;
            case 4:
                _timeBetweenWave = timeBetweenWaveList[4];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[4];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[4];
                break;
            case 5:
                _timeBetweenWave = timeBetweenWaveList[5];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[5];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[5];
                break;
            case 6:
                _timeBetweenWave = timeBetweenWaveList[6];
                _countEnemyWithOneWave = countEnemyWithOneWaveList[6];
                _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[6];
                break;
            default:
                break;
        }
        _timeBetweenSpawnEnemy = _startTimeBetweenSpawnEnemy;
    }

    public void SkipTimer()
    {
        _timeBetweenWave = 0;
        TimerToNextWaveObj.SetActive(false);
    }
}
