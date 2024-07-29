using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _damageAmount;
    [SerializeField] private Player _player;

    private bool _isAttacking = false;

    public bool IsAttacking => _isAttacking;

    public bool CanAttack
    {
        get
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < _attackDistance)
            {
                return true;
            }

            return false;
        }
    }

    public void Construct(Player player)
    {
        _player = player;
    }

    public void Attack()
    {
        if (CanAttack)
        {
            _player.TakeDamage(_damageAmount);
        }

        _isAttacking = false;
    }

    public void Attack(float multiplier)
    {
        if (CanAttack)
        {
            _player.TakeDamage(_damageAmount * multiplier);
        }

        _isAttacking = false;
    }

    public void StartAttacking()
    {
        _isAttacking = true;
    }
}
