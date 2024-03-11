using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {

    }

    public void StartGame()
    {
        LoadingScene.SwitchScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void MainMenuClick()
    {
        LoadingScene.SwitchScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
