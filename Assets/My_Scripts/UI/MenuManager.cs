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
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void MainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
