using UnityEngine;

namespace Homework.Movement
{
    /**
     * TODO:
     * 1. Реализовать этот тип перемещения по аналогии с Walk, но отличающийся от него,
     * например, пусть перемещение будет по окружности заданного радиуса. +
     * 2. Заменить передвижение у HappyDog и/или SadDog этим типом. Убедиться, что он работает. +
     */
    public class Run : Move
    {
        private readonly float _radius;
        private readonly float _speed;
        private float _angle = 0f;
        private int _direction = 1;


        public Run(MonoBehaviour owner) : base(owner)
        {
        }

        public Run(MonoBehaviour owner, float radius, float speed) : base(owner)
        {
            _radius = radius;
            _speed = speed;
        }

        public override void Execute()
        {
            _angle += _speed * Time.deltaTime;

            float x = _direction * Mathf.Cos(_angle) * _radius;
            float y = Mathf.Sin(_angle) * _radius;

            Owner.transform.position = new Vector2(x, y);

            if (_angle > 3f | _angle < -3f)
            {
                _angle -= 3f;
                _direction *= -1;
                OnDirectionChanged?.Invoke();
            }
        }
    }
}