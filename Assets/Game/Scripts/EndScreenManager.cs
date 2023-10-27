using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup winScreen;
    [SerializeField]
    private CanvasGroup gameOverScreen;


    private void Start()
    {
        Utility.SetCanvasGroupEnabled(winScreen, false);
        Utility.SetCanvasGroupEnabled(gameOverScreen, false);
    }

    public void ShowWinScreen()
    {
        Utility.SetCanvasGroupEnabled(winScreen, true);
    }

    public void ShowGameOverScreen()
    {
        Utility.SetCanvasGroupEnabled(gameOverScreen, true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneType.Menu);
    }
}
