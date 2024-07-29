using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int X = Animator.StringToHash(nameof(X));
    private readonly int Y = Animator.StringToHash(nameof(Y));
    private readonly int Jumped = Animator.StringToHash(nameof(Jumped));
    private readonly int Shot = Animator.StringToHash(nameof(Shot));
    private readonly int Died = Animator.StringToHash(nameof(Died));

    [SerializeField] private Animator _animator;

    public void SetDirectionParametrs(Vector3 direction)
    {
        _animator.SetFloat(X, direction.x);
        _animator.SetFloat(Y, direction.z);
    }

    public void StartJumpAnimation()
    {
        _animator.SetTrigger(Jumped);
    }

    public void StartShootAnimation()
    {
        _animator.SetTrigger(Shot);
    }

    public void StartDeathAnimation()
    {
        _animator.SetTrigger(Died);
    }

    public Vector3 GetCurrentDirection()
    {
        return new Vector3(_animator.GetFloat(X), 0, _animator.GetFloat(Y));
    }
}
