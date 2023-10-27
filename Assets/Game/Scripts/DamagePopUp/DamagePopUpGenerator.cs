using UnityEngine;
using TMPro;

public class DamagePopUpGenerator : MonoBehaviour
{
    public static DamagePopUpGenerator current;
    public GameObject prefab;


    private void Awake()
    {
        current = this;
    }

    public void CreatePopUp(Vector3 pos, string text)
    {
        var popup = Instantiate(prefab, pos, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        temp.text = text;

        Destroy(popup, 1f);
    }
}
