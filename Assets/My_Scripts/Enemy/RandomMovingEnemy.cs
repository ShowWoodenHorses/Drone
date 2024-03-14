using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovingEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;
    public List<Transform> randomPoint = new List<Transform>();

    private RandomSpawnManager spawnManager;

    public void Initialize(RandomSpawnManager spawner)
    {
        spawnManager = spawner;
        for (int i = 0; i < spawnManager.targetsPosition.Count; i++)
        {
            randomPoint.Add(spawnManager.targetsPosition[i]);
        }
        _target = randomPoint[Random.Range(0, randomPoint.Count)];
    }
    void Start()
    {
        if(_agent == null )
            _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _agent.SetDestination(_target.position);
        if (Vector3.Distance(transform.position, _target.position) < 1f)
        {
            ChangeTargetPoint();
        }
    }

    void ChangeTargetPoint()
    {
        _target = randomPoint[Random.Range(0, randomPoint.Count)];
    }

}
