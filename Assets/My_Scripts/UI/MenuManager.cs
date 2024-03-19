
using UnityEngine;
using GamePush;

public class MenuManager : MonoBehaviour
{

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

    public void SetPauseTime()
    {
        Time.timeScale = 0f;
    }

    public void BreakPauseTime()
    {
        Time.timeScale = 1f;
    }
}
