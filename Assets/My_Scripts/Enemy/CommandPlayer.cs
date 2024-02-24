
using System.Collections.Generic;
using UnityEngine;

public class CommandPlayer : MonoBehaviour
{
    [SerializeField] private List<Transform> _naerbyEnemies = new List<Transform> ();
    [SerializeField] private float _distanceCheckEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShowNearbyEnemies();
        }
    }

    private void ShowNearbyEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distanceCheckEnemy);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.GetComponent<CheckNearbyEnemy>() != null)
            {
                collider.transform.GetComponent<CheckNearbyEnemy>().ShowEnemy();
            }
        }
    }
}
