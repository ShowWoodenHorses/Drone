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
    [SerializeField] private TextMeshProUGUI _textCurrentWaveForPause;
    [SerializeField] private TextMeshProUGUI _textTimeToTheNextWaveForPause;

    //Arraies
    [SerializeField] private List<int> countEnemyWithOneWaveList = new List<int>();
    [SerializeField] private List<float> timeBetweenWaveList = new List<float>();
    [SerializeField] private List<float> startTimeBetweenSpawnEnemyList = new List<float>();



    private void Start()
    {
        _timeBetweenSpawnEnemy = _startTimeBetweenSpawnEnemy;
        ChangeWave(_currentWave);
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
                ++_currentWave;
                ChangeWave(_currentWave);
                TimerToNextWaveObj.SetActive(true);
            }
        }
    }

    public void SkipTimer()
    {
        _timeBetweenWave = 0;
        TimerToNextWaveObj.SetActive(false);
    }

    public void ChangeWave(int index)
    {
        if (_currentWave > _countWave)
        {
            _currentWave = 0;
            index = 0;
        }
        int nextIndex = index + 1;
        _timeBetweenWave = timeBetweenWaveList[index];
        _countEnemyWithOneWave = countEnemyWithOneWaveList[index];
        _startTimeBetweenSpawnEnemy = startTimeBetweenSpawnEnemyList[index];
        _textCurrentWaveForPause.text = _currentWave.ToString();
        if (nextIndex < timeBetweenWaveList.Count)
        {
            _textTimeToTheNextWaveForPause.text = Mathf.Round(timeBetweenWaveList[nextIndex]).ToString();
        }
        _timeBetweenSpawnEnemy = _startTimeBetweenSpawnEnemy;
        if (_currentWave == 3)
            spawnerList.Add(spawnManagerWater);
    }
}
