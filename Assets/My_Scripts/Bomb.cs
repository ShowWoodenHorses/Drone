
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _effectExplotion;
    [SerializeField] private GameObject _effectInteraction;
    public bool _isAttack = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<EnemyController>())
        {
            GameObject explotion = Instantiate(_effectExplotion, transform.position, Quaternion.identity);
            other.transform.GetComponent<EnemyController>().TakeDamage(_damage);
            Destroy(explotion, 1f);
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject interaction = Instantiate(_effectInteraction, transform.position, Quaternion.identity);
            Destroy(interaction, 1f);
            Destroy(gameObject);
            return;
        }
    }
}
