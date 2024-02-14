using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeDrone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.GetComponent<DropBomb>())
        {
            Debug.Log("DropBomb");
            DropBomb dropBomb = other.gameObject.GetComponent<DropBomb>();
            if (dropBomb.countBomb < dropBomb.maxCountBomb)
            {
                Debug.Log("countBomb");
                dropBomb.countBomb = dropBomb.maxCountBomb;
            }
        }
    }
}
