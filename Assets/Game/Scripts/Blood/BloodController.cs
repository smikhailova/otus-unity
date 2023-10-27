using UnityEngine;

public class BloodController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodDrops;


    public void GenerateBloodDrops(Transform targetTransform)
	{
        Instantiate(_bloodDrops, targetTransform.position, Quaternion.identity);
    }
}
