using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioBackFonMusic;
    [SerializeField] private Toggle _hintsToggle;
    [SerializeField] private Toggle _populationToggle;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _volumeMusicSlider;
    [SerializeField] private GameObject _iconActiveSound;
    [SerializeField] private GameObject _iconDeactiveSound;
    [SerializeField] private GameObject _iconActiveMusic;
    [SerializeField] private GameObject _iconDeactiveMusic;

    public float currentVolume;
    public float currentVolumeMusic;

    public static bool isHints = false;
    public static bool isPopulation = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumeSetting"))
        {
            _volumeSlider.value = PlayerPrefs.GetFloat("VolumeSetting");
        }
        if (PlayerPrefs.HasKey("VolumeMusic"))
        {
            _volumeMusicSlider.value = PlayerPrefs.GetFloat("VolumeMusic");
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
        currentVolumeMusic = _volumeMusicSlider.value;
        if (currentVolumeMusic < 0.05f)
        {
            _iconDeactiveMusic.SetActive(true);
            _iconActiveMusic.SetActive(false);
        }
        else
        {
            _iconDeactiveMusic.SetActive(false);
            _iconActiveMusic.SetActive(true);
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
        if (currentVolumeMusic != _volumeMusicSlider.value)
        {
            currentVolumeMusic = _volumeMusicSlider.value;
            if (currentVolumeMusic < 0.05f)
            {
                _volumeMusicSlider.value = 0;
                currentVolumeMusic = 0;
                _iconDeactiveMusic.SetActive(true);
                _iconActiveMusic.SetActive(false);
            }
            else
            {
                _iconDeactiveMusic.SetActive(false);
                _iconActiveMusic.SetActive(true);
            }
            PlayerPrefs.SetFloat("VolumeMusic", _volumeMusicSlider.value);
            PlayerPrefs.Save();
        }
        audioBackFonMusic.volume = _volumeMusicSlider.value;
    }
}
