using UnityEngine;

namespace Game.Scripts
{
    public sealed class AttackController : MonoBehaviour
    {
        [SerializeField]
        private Player player;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.player.Attack();
                return;
            }
        }
    }
}