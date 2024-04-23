
using UnityEngine;
using GamePush;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioButton;
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
        GP_Game.GameplayStop();
    }

    public void BreakPauseTime()
    {
        Time.timeScale = 1f;
        GP_Game.GameplayStart();
    }

    public void SoundClick()
    {
        _audioButton.Play();
    }

    public void OnInviteButton()
    {
        GP_Socials.Share();
    }
    public void OnLeaderboardButton()
    {
        GP_Leaderboard.Open();
    }

    public void OnGamePeopleButton()
    {
        Application.OpenURL("https://t.me/bvvgames");
    }
}
