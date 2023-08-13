using Homework.Common;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * 1. Добавить всем собакам способность гавкать: достаточно метода, пишущего в Unity-консоль строку с сообщение. +
     * 2. HappyDog должен гавкать более радостно. +
     * 3. (сложно) Пусть собаки гавкают только тогда, когда меняют направление движения. +
     */
    public abstract class Dog : MonoBehaviour, IColorChangeable, IBarkable
    {
        public abstract void ChangeColor();
        public abstract void MoveBody();
        public abstract void Bark();

        protected Move move;
        protected SpriteRenderer spriteRenderer;


        protected void Start()
        {
            MoveBody();

            InputController.Instance.OnColorChanged += OnColorChanged;
            Move.Instance.OnDirectionChanged += OnDirectionChanged;
        }

        protected void Update()
        {
            move.Execute();
        }

        private void OnDestroy()
        {
            InputController.Instance.OnColorChanged -= OnColorChanged;
            Move.Instance.OnDirectionChanged -= OnDirectionChanged;
        }

        private void OnColorChanged()
        {
            ChangeColor();
        }

        private void OnDirectionChanged()
        {
            Bark();
        }

        protected SpriteRenderer GetSpriteRenderer()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            return spriteRenderer;
        }
    }
}