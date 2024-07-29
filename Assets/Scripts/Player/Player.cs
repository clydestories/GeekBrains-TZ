using System;
using UnityEngine;

[RequireComponent (typeof(PlayerMover), typeof(Looker), typeof(PlayerAnimator))]
[RequireComponent (typeof(PlayerShooter), typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    private const float PausedTimeScale = 0;

    [SerializeField] private InputReader _input;
    [SerializeField] private WeaponInventory _weapons;

    private PlayerMover _mover;
    private Looker _looker;
    private PlayerAnimator _animator;
    private PlayerShooter _shooter;
    private PlayerHealth _health;

    public event Action Died;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _looker = GetComponent<Looker>();
        _animator = GetComponent<PlayerAnimator>();
        _shooter = GetComponent<PlayerShooter>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _input.Moved += Move;
        _input.Looked += Look;
        _input.Jumped += Jump;
        _input.Shot += Shoot;
        _input.Reloaded += Reload;
        _input.WeaponPicked += ChangeWeapon;
        _health.Died += OnDeath;
    }

    private void OnDisable()
    {
        _input.Moved -= Move;
        _input.Looked -= Look;
        _input.Jumped -= Jump;
        _input.Shot -= Shoot;
        _input.Reloaded -= Reload;
        _input.WeaponPicked -= ChangeWeapon;
        _health.Died -= OnDeath;
    }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    private void Move(Vector3 direction)
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _mover.Move(direction);
            _animator.SetDirectionParametrs(SmoothDirection(_animator.GetCurrentDirection(), direction));
        }
    }

    private void Jump()
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _mover.Jump();
            _animator.StartJumpAnimation();
        }
    }

    private void Look(Vector2 offset) 
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _looker.Look(offset);
        }
    }

    private void Shoot()
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _shooter.Shoot();
            _animator.StartShootAnimation();
        }
    }

    private void Reload()
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _shooter.Reload();
        }
    }

    private void ChangeWeapon(int weaponName)
    {
        if (Time.timeScale != PausedTimeScale)
        {
            _weapons.ChangeWeapon(weaponName);
        }
    }

    private Vector3 SmoothDirection(Vector3 origin, Vector3 target)
    {
        return Vector3.MoveTowards(origin, target, 0.05f);
    }

    private void OnDeath()
    {
        Died?.Invoke();
        _animator.StartDeathAnimation();
        _mover.enabled = false;
        _looker.enabled = false;
        _shooter.enabled = false;
        enabled = false;
    }
}
