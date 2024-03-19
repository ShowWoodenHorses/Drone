using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{

    [SerializeField] private Toggle _hintsToggle;
    [SerializeField] private Toggle _populationToggle;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _iconActiveSound;
    [SerializeField] private GameObject _iconDeactiveSound;

    public static float currentVolume;

    public static bool isHints = false;
    public static bool isPopulation = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumeSetting"))
        {
            _volumeSlider.value = PlayerPrefs.GetFloat("VolumeSetting");
        }
        currentVolume = _volumeSlider.value;
        if (currentVolume < 0.05f)
        {
            _iconDeactiveSound.SetActive(true);
            _iconActiveSound.SetActive(false);
        }
        else
        {
            _iconDeactiveSound.SetActive(false);
            _iconActiveSound.SetActive(true);
        }
        _hintsToggle.isOn = isHints;
        _populationToggle.isOn = isPopulation;
    }
    private void Update()
    {
        isHints = _hintsToggle.isOn;
        isPopulation = _populationToggle.isOn;
        if (currentVolume != _volumeSlider.value)
        {
            currentVolume = _volumeSlider.value;
            if (currentVolume < 0.05f)
            {
                _volumeSlider.value = 0;
                currentVolume = 0;
                _iconDeactiveSound.SetActive(true);
                _iconActiveSound.SetActive(false);
            }
            else
            {
                _iconDeactiveSound.SetActive(false);
                _iconActiveSound.SetActive(true);
            }
            PlayerPrefs.SetFloat("VolumeSetting", _volumeSlider.value);
            PlayerPrefs.Save();
        }
    }
}
