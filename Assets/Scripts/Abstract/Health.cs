using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _value;

    public event Action Died;
    public event Action<float, float> ValueChanged;

    public float Value
    {
        get { return _value; }
        set 
        {
            _value = Mathf.Clamp(value, 0, _maxValue); 
        }
    }

    private void Start()
    {
        Value = _maxValue;
        ValueChanged?.Invoke(Value, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage can't be negative");
        }

        Value -= damage;
        ValueChanged?.Invoke(Value, _maxValue);

        if (Value == 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Healing amount can't be negative");
        }

        Value += amount;
        ValueChanged?.Invoke(Value, _maxValue);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
