using UnityEngine;

public sealed class Player : MonoBehaviour
{
    private static readonly int State = Animator.StringToHash("State");
    private const int IDLE_ANIM_STATE = 0;
    private const int MOVE_ANIM_STATE = 1;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Animator animator;

    private Vector3 moveDirection;
    private bool isMoving;

    private AnimationEventHandler eventHandler;

    public bool isAttaking;


    private void Awake()
    {
        eventHandler = animator.GetComponent<AnimationEventHandler>();
    }

    public void Move(Vector3 direction)
    {
        moveDirection = direction;
        isMoving = true;
    }

    public void Attack()
    {
        isAttaking = true;
        animator.SetTrigger("FistAttack");
    }

    public void FinishAttack()
    {
        isAttaking = false;
    }

    private void OnEnable()
    {
        eventHandler.OnFinish += FinishAttack;
    }

    private void OnDisable()
    {
        eventHandler.OnFinish -= FinishAttack;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            UpdateMovement();
            animator.SetInteger(State, MOVE_ANIM_STATE);
            isMoving = false;
        }
        else
        {
            animator.SetInteger(State, IDLE_ANIM_STATE);
        }
    }

    private void UpdateMovement()
    {
        var deltaTime = Time.fixedDeltaTime;
        transform.position += moveDirection * moveSpeed * deltaTime;

        var targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        var nextRotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * deltaTime
        );
        transform.rotation = nextRotation;
    }
}
