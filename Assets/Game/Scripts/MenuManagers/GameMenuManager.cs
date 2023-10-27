using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup gameMenu;


    private void Start()
    {
        CloseGameMenu();
    }

    public void OpenGameMenu()
    {
        Utility.SetCanvasGroupEnabled(gameMenu, true);
        PauseOn();
    }

    private void CloseGameMenu()
    {
        Utility.SetCanvasGroupEnabled(gameMenu, false);
        PauseOff();
    }

    public void Continue()
    {
        CloseGameMenu();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneType.Menu);
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void PauseOn()
    {
        Time.timeScale = 0;
    }

    private void PauseOff()
    {
        Time.timeScale = 1;
    }
}
