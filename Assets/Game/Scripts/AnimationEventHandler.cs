using System;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public event Action OnFinish;


    public void AnimationFinishedTrigger() => OnFinish?.Invoke();
}
