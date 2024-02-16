using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject bomb;
    public byte maxCountBomb;
    public byte countBomb;

    private void Start()
    {
        countBomb = maxCountBomb;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (countBomb > 0)
            {
                countBomb--;
                GameObject obj = Instantiate(bomb, spawnPos.position, Quaternion.identity);
                Destroy(obj, 15f);
            }
        }
    }
}
