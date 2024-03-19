using GamePush;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSettings : MonoBehaviour
{
    public static MainGameSettings instance;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (instance == null)
            instance = this;
    }
    private void OnEnable()
    {
        GP_Game.OnPause += PauseGame;
        GP_Game.OnResume += UnPauseGame;
    }
    private void OnDisable()
    {
        GP_Game.OnPause -= PauseGame;
        GP_Game.OnResume -= UnPauseGame;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
