using UnityEngine;

public class DamagePopUpController : MonoBehaviour
{
    public void CreatePopUp(Transform targetTransform, string damageAmount)
	{
        DamagePopUpGenerator.current.CreatePopUp(targetTransform.position, damageAmount);
    }
}
