using UnityEngine;

public class AssasinEnemy : Enemy
{
    private readonly float _maxChance = 1;
    private readonly float _minChance = 0;

    [SerializeField, Range(0, 1)] private float _criticalChance;
    [SerializeField] private float _criticalMultiplier;

    protected override void Attack()
    {
        if (_criticalChance <= Random.Range(_minChance, _maxChance))
        {
            Attacker.Attack(_criticalMultiplier);
            EnemyMover.StartMoving();
        }
        else
        {
            base.Attack();
        }
    }
}
