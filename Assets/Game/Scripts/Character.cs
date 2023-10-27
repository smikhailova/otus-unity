using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        private static readonly int State = Animator.StringToHash("State");
        private const int IDLE_ANIM_STATE = 0;
        private const int MOVE_ANIM_STATE = 1;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Weapon _weapon;

        [SerializeField]
        private Health _health;
        public bool IsAlive => _health.IsAlive;

        private AnimationEventHandler _eventHandler;
        private bool _isAttaking;

        private static readonly int _speed = 5;
        private Vector3 _targetPos;
        private Vector3 _moveDirection;
        private bool _isTargetAssigned = false;
        private float _deltaPos;
        private bool _isMoving;


        private void Awake()
        {
            _eventHandler = _animator.GetComponent<AnimationEventHandler>();
        }

        private void OnEnable()
        {
            _eventHandler.OnFinish += FinishAttack;
            _health.OnDeath += OnHealthDeath;
        }

        private void OnDisable()
        {
            _eventHandler.OnFinish -= FinishAttack;
            _health.OnDeath -= OnHealthDeath;
        }

        public IEnumerator Attack(Character attackedCharacter)
        {
            _isAttaking = true;

            Debug.Log($"{GetType().Name}.Attack: gameObject.name = {gameObject.name} => {attackedCharacter.gameObject.name}");

            var animationName = WeaponHelpers.GetAnimationName(_weapon.Type);
            _animator.SetTrigger(animationName);

            yield return new WaitUntil(() => !_isAttaking);

            attackedCharacter.TakeDamage(_weapon.Damage);
        }

        public void TakeDamage(int damage)
        {
            StartCoroutine(_health.TakeDamage(transform, damage));
        }

        public void OnHealthDeath()
        {
            Debug.Log($"{GetType().Name}.Die: name = {name}");
            var animationName = HealthHelpers.GetAnimationName(HealthActionType.Die);
            _animator.SetTrigger(animationName);
        }

        public void FinishAttack()
        {
            _isAttaking = false;
        }

        public void SetTarget(Vector3 targetPos)
        {
            _targetPos = targetPos;
            _moveDirection = (_targetPos - transform.position).normalized;
            _isTargetAssigned = true;
        }

        public void Move(float deltaPos)
        {
            _deltaPos = deltaPos;
            _isMoving = true;
        }

        private void FixedUpdate()
        {
            if (_isTargetAssigned)
            {
                if (_isMoving)
                {
                    UpdateMovement();
                    _animator.SetInteger(State, MOVE_ANIM_STATE);
                    var stopPos = Mathf.Abs(transform.position.z - _targetPos.z);
                    if (stopPos <= _deltaPos) _isMoving = false;
                }
                else _animator.SetInteger(State, IDLE_ANIM_STATE);

                UpdateRotation();
            }
        }

        private void UpdateMovement()
        {
            transform.position += _speed * Time.fixedDeltaTime * _moveDirection;
        }

        public void UpdateRotation()
        {
            var targetRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.fixedDeltaTime);
        }
    }
}