using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private string nameSkin;
    [SerializeField] private int skinID;
    public Transform spawnPos;
    [SerializeField] private List<GameObject> bombs = new List<GameObject>();
    [SerializeField] private GameObject _bomb;
    public byte maxCountBomb;
    public byte countBomb;

    private void Start()
    {
        skinID = PlayerPrefs.GetInt(nameSkin);
        _bomb = bombs[skinID];
        countBomb = maxCountBomb;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (countBomb > 0)
            {
                countBomb--;
                GameObject obj = Instantiate(_bomb, spawnPos.position, Quaternion.identity);
                Destroy(obj, 15f);
            }
        }
    }
}
