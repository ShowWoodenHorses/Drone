using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField] private string nameSkin;
    [SerializeField] private int skinID;
    public Transform spawnPos;
    [SerializeField] private List<GameObject> bombs = new List<GameObject>();
    [SerializeField] private GameObject _bomb;
    public int maxCountBomb;
    public int countBomb;

    public float maxHeight;
    [SerializeField] private float _minHeight;

    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = PlayerPrefs.GetFloat("VolumeSetting");
        skinID = PlayerPrefs.GetInt(nameSkin);
        _bomb = bombs[skinID];
        countBomb = maxCountBomb;
    }
    void Update()
    {
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBombClick();
        }
    }

    public void DropBombClick()
    {
        if (countBomb > 0)
        {
            _audio.Play();
            countBomb--;
            GameObject obj = Instantiate(_bomb, spawnPos.position, Quaternion.identity);
            Destroy(obj, 15f);
        }
    }
}
