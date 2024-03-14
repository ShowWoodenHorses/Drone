using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnManager : MonoBehaviour
{
    public List<GameObject> prefabsRandomEnemy = new List<GameObject>();
    public List<Transform> positionsForEnemy = new List<Transform>();
    public List<Transform> targetsPosition = new List<Transform>();

    private RandomSpawnManager spawnManager;
    void Start()
    {
        spawnManager = this;
        for (int i = 0; i < positionsForEnemy.Count; i++)
        {
            GameObject enemy = Instantiate(prefabsRandomEnemy[Random.Range(0, prefabsRandomEnemy.Count)],
                positionsForEnemy[i].position, Quaternion.identity);
            enemy.GetComponent<RandomMovingEnemy>().Initialize(spawnManager);
        }
    }
}
