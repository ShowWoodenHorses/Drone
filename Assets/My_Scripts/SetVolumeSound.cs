using UnityEngine;

public class SetVolumeSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private string _nameSaveAudio;
    private void Awake()
    {
        if (_audio == null)
            _audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("VolumeMusic"))
            _audio.volume = PlayerPrefs.GetFloat("VolumeMusic");
        else
            _audio.volume = 0;
        AudioListener.pause = false;
    }
}
