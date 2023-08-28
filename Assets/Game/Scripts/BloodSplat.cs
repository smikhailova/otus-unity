using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    void Start()
    {
        this.transform.localScale = Vector3.one * Random.Range(.05f, .1f);
        this.transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
    }
}
