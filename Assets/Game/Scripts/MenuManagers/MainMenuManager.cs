using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    enum Screen
    {
        None,
        Main,
        Settings,
        Level
    }

    enum Level
    {
        Easy,
        Medium,
        Hard
    }

    [SerializeField]
    private CanvasGroup mainScreen;
    [SerializeField]
    private CanvasGroup settingsScreen;
    [SerializeField]
    private CanvasGroup levelScreen;

    private Level level = Level.Medium;

    [SerializeField]
    private TMP_Text levelText;


    private void Start()
    {
        SetCurrentScreen(Screen.Main);

        levelText.text = level.ToString();
    }

    private void FixedUpdate()
    {
        levelText.text = level.ToString();
    }

    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(levelScreen, screen == Screen.Level);
    }

    public void StartNewGame()
    {
        SetCurrentScreen(Screen.None);

        switch (level)
        {
            case Level.Easy:
                SceneManager.LoadScene(SceneType.GameEasy);
                break;
            case Level.Medium:
                SceneManager.LoadScene(SceneType.GameMedium);
                break;
            case Level.Hard:
                SceneManager.LoadScene(SceneType.GameHard);
                break;
            default:
                break;
        }
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void CloseSettings()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void OpenLevel()
    {
        SetCurrentScreen(Screen.Level);
    }

    public void EasyLevel()
    {
        level = Level.Easy;
    }

    public void MediumLevel()
    {
        level = Level.Medium;
    }

    public void HardLevel()
    {
        level = Level.Hard;
    }

    public void CloseLevel()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
