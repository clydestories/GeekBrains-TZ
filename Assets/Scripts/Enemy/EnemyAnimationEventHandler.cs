using System;
using UnityEngine;

public class EnemyAnimationEventHandler : MonoBehaviour
{
    public event Action Attacked;
    public event Action Healed;

    public void OnAttacked()
    {
        Attacked.Invoke();
    }

    public void OnHealed()
    {
        Healed.Invoke();
    }
}
