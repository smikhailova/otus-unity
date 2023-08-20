using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
