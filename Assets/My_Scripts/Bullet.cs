
using UnityEngine;

public class Bullet : MonoBehaviour, ICanAttack
{
    private protected GameObject _player;

    [SerializeField] private protected int _damage;
    [SerializeField] private protected float _speed;

    private Rigidbody _rb;
    Vector3 _playerPosition;
    public void InitializeAttack(GameObject player)
    {
        _player = player;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Vector3 direction = _player.transform.position - transform.position;
        Quaternion rotate = transform.rotation;
        transform.rotation = Quaternion.RotateTowards(rotate,
            Quaternion.LookRotation(direction), 1000f);
        _playerPosition = _player.transform.position;
    }

    private void Update()
    {
        _rb.AddForce(transform.forward * _speed * Time.deltaTime,ForceMode.Impulse);
        Destroy(gameObject,5f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerHealth>())
        {
            other.transform.GetComponent<PlayerHealth>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
