using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Image _healthBar;


    public void UpdateHealthBar(float fillAmount)
    {
        _healthBar.fillAmount = fillAmount;
    }
}
