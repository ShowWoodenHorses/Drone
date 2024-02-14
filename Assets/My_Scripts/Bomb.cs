
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _rb;
    public bool _isAttack = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<EnemyController>())
        {
            other.transform.GetComponent<EnemyController>().TakeDamage(_damage);
        }
    }
}
