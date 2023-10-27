using UnityEngine;

public class Utility : MonoBehaviour
{
    public static void SetCanvasGroupEnabled(CanvasGroup group, bool isEnabled)
    {
        group.alpha = (isEnabled) ? 1.0f : 0.0f;
        group.interactable = isEnabled;
        group.blocksRaycasts = isEnabled;
    }
}
