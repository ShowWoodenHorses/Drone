using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayerObject : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private List<GameObject> skinsObj = new List<GameObject>();
    [SerializeField] private List<SkinSettingsSO> skinsSettings = new List<SkinSettingsSO>();
    public string nameSkin;

    private Rigidbody _rb;
    private DropBomb _dropBomb;
    private ButtonHandler _buttonHandler;
    private void Awake()
    {
        PlayerPrefs.Save();
        _rb = GetComponent<Rigidbody>();
        _dropBomb = GetComponent<DropBomb>();
        _buttonHandler = GetComponent<ButtonHandler>();
        int scinsID = PlayerPrefs.GetInt(nameSkin);
        for (int i = 0; i < skinsObj.Count; i++)
        {
            skinsObj[i].SetActive(false);
        }
        skinsObj[scinsID].SetActive(true);
        _rb.mass = skinsSettings[scinsID].mass;
        _dropBomb.maxCountBomb = skinsSettings[scinsID].maxCountBomb;
        _dropBomb.maxHeight = skinsSettings[scinsID].maxHeight;
        _buttonHandler.speedRotate = skinsSettings[scinsID].speedRotateMobile;
        _buttonHandler.speedUpDown = skinsSettings[scinsID].speedUpDownMobile;
    }
    private void Start()
    {
        _audio.volume = PlayerPrefs.GetFloat("VolumeSetting");
    }
}
