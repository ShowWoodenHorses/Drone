using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayerObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> skinsObj = new List<GameObject>();
    public string nameSkin;
    int money = 500;
    private void Start()
    {
        PlayerPrefs.SetInt("CountKillAll", money);
        PlayerPrefs.Save();
        int scinsID = PlayerPrefs.GetInt(nameSkin);
        for (int i = 0; i < skinsObj.Count; i++)
        {
            skinsObj[i].SetActive(false);
        }
        skinsObj[scinsID].SetActive(true);
    }
}
