
using UnityEngine;
using UnityEngine.Serialization;

public class Bomb : MonoBehaviour
{
    [SerializeField] private protected float _distance;
    [SerializeField] private protected int _damage;
    [SerializeField] private protected float _delayDestroy;
    [SerializeField] private protected Rigidbody _rb;
    [SerializeField] private protected GameObject _effectExplotion;
    [SerializeField] private protected GameObject _effectInteraction;
    [SerializeField] private protected GameObject _raduisAttackObj;
    [SerializeField] private protected bool _isDestroyEffect = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<EnemyController>())
        {
            GameObject explotion = Instantiate(_effectExplotion, transform.position, Quaternion.identity);
            other.transform.GetComponent<EnemyController>().TakeDamage(_damage);
            Destroy(explotion, _delayDestroy);
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject interaction = Instantiate(_effectInteraction, transform.position, Quaternion.identity);
            if (_isDestroyEffect)
            {
                Destroy(interaction, _delayDestroy);
                RadiusDamage();
            }
            Destroy(gameObject);
            return;
        }
    }

    void RadiusDamage()
    {
        GameObject radiusAttack = Instantiate(_raduisAttackObj, transform.position, Quaternion.identity);
        Destroy(radiusAttack, _delayDestroy);
    }
}
