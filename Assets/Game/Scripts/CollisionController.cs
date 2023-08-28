using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;


    private void OnTriggerEnter(Collider other)
    {
        if (player.isAttaking && other.gameObject.CompareTag("Police"))
        {
            this.enemy.TakeDamage(10);
        }
    }
}
