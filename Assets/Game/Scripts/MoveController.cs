using UnityEngine;

namespace Game.Scripts
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        private Transform mainCameraTransform;


        private void Start()
        {
            mainCameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 cameraForward = Vector3.Scale(mainCameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveDirection = (cameraForward * verticalInput + mainCameraTransform.right * horizontalInput).normalized;

            this.player.Move(moveDirection);
        }
    }
}