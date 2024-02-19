
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private protected float _distance;
    [SerializeField] private protected int _damage;
    [SerializeField] private protected Rigidbody _rb;
    [SerializeField] private protected GameObject _effectExplotion;
    [SerializeField] private protected GameObject _effectInteraction;
    [SerializeField] private protected GameObject _raduisAttackObj;


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
            RadiusDamage();
            Destroy(gameObject);
            return;
        }
    }

    void RadiusDamage()
    {
        GameObject radiusAttack = Instantiate(_raduisAttackObj, transform.position, Quaternion.identity);
        Destroy(radiusAttack, 1f);
    }
}
