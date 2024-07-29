using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private readonly int Died = Animator.StringToHash(nameof(Died));
    private readonly int Attacked = Animator.StringToHash(nameof(Attacked));
    private readonly int Speed = Animator.StringToHash(nameof(Speed));
    private readonly int Healing = Animator.StringToHash(nameof(Healing));

    [SerializeField] private Animator _animator;

    public void StartAttackAnimation()
    {
        _animator.SetTrigger(Attacked);
    }

    public void StartDeathAnimation()
    {
        _animator.SetTrigger(Died);
    }

    public void StartHealAnimation()
    {
        _animator.SetTrigger(Healing);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }
}
