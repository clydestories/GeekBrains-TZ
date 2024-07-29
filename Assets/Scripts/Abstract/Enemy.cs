using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyMover), typeof(EnemyAnimator), typeof(EnemyHealth))]
[RequireComponent (typeof(Collider), typeof(EnemyAttacker))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyAnimationEventHandler EventHandler;

    [SerializeField] private HealthDisplay _healthDisplay;
    [SerializeField] private float _destroyDelay;

    protected EnemyMover EnemyMover;
    protected EnemyAttacker Attacker;
    protected EnemyHealth Health;
    protected EnemyAnimator Animator;

    private Collider _collider;

    public event Action<Enemy> Died;

    private void Awake()
    {
        EnemyMover = GetComponent<EnemyMover>();
        Animator = GetComponent<EnemyAnimator>();
        Health = GetComponent<EnemyHealth>();
        _collider = GetComponent<Collider>();
        Attacker = GetComponent<EnemyAttacker>();
    }

    private void OnEnable()
    {
        SubscribeListeners();
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
    }

    public void Construct(Player player, List<Transform> points)
    {
        EnemyMover.Construct(player, points);
        Attacker.Construct(player);
    }

    protected virtual void Attack()
    {
        Attacker.Attack();
        EnemyMover.StartMoving();
    }

    protected void SubscribeListeners()
    {
        Health.Died += OnDeath;
        EventHandler.Attacked += Attack;
    }

    protected void UnsubscribeListeners()
    {
        Health.Died -= OnDeath;
        EventHandler.Attacked -= Attack;
    }

    private void Move()
    {
        if (EnemyMover.IsPlayerSeen)
        {
            EnemyMover.ChasePlayer();
            Animator.SetSpeed(EnemyMover.ChasingSpeed / EnemyMover.MaxSpeed);

            if (Attacker.CanAttack && Attacker.IsAttacking == false)
            {
                Attacker.StartAttacking();
                EnemyMover.Stop();
                Animator.StartAttackAnimation();   
            }
        }
        else
        {
            EnemyMover.Patrol();
            Animator.SetSpeed(EnemyMover.PatrolingSpeed / EnemyMover.MaxSpeed);
        }
    }

    private void OnDeath()
    {
        Died?.Invoke(this);
        Animator.StartDeathAnimation();
        _collider.enabled = false;
        Health.enabled = false;
        _healthDisplay.gameObject.SetActive(false);
        Attacker.enabled = false;
        EnemyMover.Stop();
        EnemyMover.enabled = false;
        enabled = false;
        Destroy(gameObject, _destroyDelay);
    }
}
