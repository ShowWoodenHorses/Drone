
using UnityEngine;

public class RadiusAttackBomb : MonoBehaviour
{
    [SerializeField] private float _radius;
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<IDamagable>()?.TakeDamage(1);
        }
        Destroy(gameObject,1f);
    }
}
