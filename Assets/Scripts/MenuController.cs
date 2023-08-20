using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Sort()
    {
        SceneManager.LoadScene(1);
    }

    public void FindPath()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(3);
    }
}
