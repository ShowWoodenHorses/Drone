using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioButton;

    public void StartGame()
    {
        LoadingScene.SwitchScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void StartGame2()
    {
        LoadingScene.SwitchScene("GameScene_2");
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

    public void SoundClick()
    {
        _audioButton.Play();
    }

    public void OnInviteButton()
    {
    }

    public void OnLeaderboardButton()
    {
    }

    public void OnGamePeopleButton()
    {
        Application.OpenURL("https://t.me/bvvgames");
    }
}