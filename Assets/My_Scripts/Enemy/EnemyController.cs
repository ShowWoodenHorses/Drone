using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] private protected int _maxHealth;
    [SerializeField] private protected int _health;
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private GameObject _target;
    public GameObject player;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    public void Initialize(GameObject target)
    {
        _target = target;
    }

    public void Initialize(GameObject target, GameObject player)
    {
        _target = target;
        this.player = player;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _agent.SetDestination(_target.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
        {
            Quaternion newRotation = Quaternion.Euler(-hit.transform.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = newRotation;
        }
    }
    public GameObject SetTargetObj()
    {
        return _target;
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
