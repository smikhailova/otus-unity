using System;
using UnityEngine;

namespace Homework.Movement
{
    public abstract class Move
    {
        protected MonoBehaviour Owner;
        public static Move Instance;

        public Action OnDirectionChanged;

        protected Move(MonoBehaviour owner)
        {
            Owner = owner;
            Instance = this;
        }

        public abstract void Execute();
    }
}