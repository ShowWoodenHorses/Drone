using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public delegate void TargetAction();
    public static TargetAction targetAction;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.GetComponent<EnemyController>())
        {
            Debug.Log("Target");
            other.gameObject.GetComponent<EnemyController>().Die();
            targetAction();
        }
    }
}
