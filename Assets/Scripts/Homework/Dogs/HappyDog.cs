using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    public class HappyDog : Dog
    {
        public override void ChangeColor()
        {
            var random = new System.Random();
            var red = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.5f + red / 2, 0.1f, 0.1f);
        }

        public override void Bark()
        {
            Debug.Log("woof-woof! :)");
        }

        public override void MoveBody()
        {
            move = new Run(this, 3, 2);
        }
    }
}