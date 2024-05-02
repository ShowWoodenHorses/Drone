using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirectionIndividualObjects : ArrowDrection
{
    public List<GameObject> individualObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < individualObjects.Count; i++)
        {
            GameObject arrowObj = Instantiate(arrow, individualObjects[i].transform.position, Quaternion.identity);
            arrowObj.transform.SetParent(_canvas.transform, false);
            enemiesDictonary.Add(individualObjects[i], arrowObj);
        }
    }
    
}