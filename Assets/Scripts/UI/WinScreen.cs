using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private readonly int Showing = Animator.StringToHash(nameof(Showing));

    [SerializeField] private Animator _animator;

    public void Show()
    {
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        _animator.SetTrigger(Showing);
    }
}
