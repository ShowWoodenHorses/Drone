using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayerObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> skinsObj = new List<GameObject>();
    [SerializeField] private List<SkinSettingsSO> skinsSettings = new List<SkinSettingsSO>();
    public string nameSkin;

    private Rigidbody _rb;
    private DropBomb _dropBomb;
    int money = 500;
    private void Awake()
    {
        PlayerPrefs.SetInt("CountKillAll", money);
        PlayerPrefs.Save();
        _rb = GetComponent<Rigidbody>();
        _dropBomb = GetComponent<DropBomb>();
        int scinsID = PlayerPrefs.GetInt(nameSkin);
        for (int i = 0; i < skinsObj.Count; i++)
        {
            skinsObj[i].SetActive(false);
        }
        skinsObj[scinsID].SetActive(true);
        _rb.mass = skinsSettings[scinsID].mass;
        _dropBomb.maxCountBomb = skinsSettings[scinsID].maxCountBomb;
        _dropBomb.maxHeight = skinsSettings[scinsID].maxHeight;
    }
}
