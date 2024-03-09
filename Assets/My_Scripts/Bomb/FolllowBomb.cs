using System.Collections.Generic;
using UnityEngine;

public class FolllowBomb : Bomb
{
    [SerializeField] private float _minDistance;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private List<GameObject> hitsObj = new List<GameObject>();

    private void Start()
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
    private void Update()
    {
        hitsObj.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distance, _layerMask);
        foreach (Collider collider in colliders)
        {
            hitsObj.Add(collider.transform.gameObject);
        }

        GameObject targetObj = null;
        foreach (GameObject obj in hitsObj)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < _minDistance)
            {
                _minDistance = distance;
                targetObj = obj;
            }
        }
        _target = targetObj;
        FollowToTarget();
    }

    void FollowToTarget()
    {
        if (_target == null)
            return;
        else
        {
            Vector3 direction = _target.transform.position - transform.position;
            Quaternion rotate = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(rotate,
                Quaternion.LookRotation(direction), 1000f);
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position,
                _speed * Time.deltaTime);
        }
    }
}
