using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private NavMeshAgent _agent;

    public GameObject target;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health < _maxHealth)
            {
                Die();
            }
        }
    }
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _agent.SetDestination(target.transform.position);
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("Damage");
    }
}
