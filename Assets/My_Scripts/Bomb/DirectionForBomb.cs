using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionForBomb : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            obj.transform.position = hit.point;
        }
        
    }
}
