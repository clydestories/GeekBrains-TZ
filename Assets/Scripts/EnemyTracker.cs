using System;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private int _enemiesCount = 0;
    private bool _isActive = false;

    public event Action AllEnemiesKilled;

    private void Update()
    {
        if (_isActive && _enemiesCount == 0)
        {
            _isActive = false;
            AllEnemiesKilled?.Invoke();
        }
    }

    public void AddEnemyCount()
    {
        _isActive = true;
        _enemiesCount++;
    }

    public void RemoveEnemyCount(Enemy enemy) 
    { 
        enemy.Died -= RemoveEnemyCount;
        _enemiesCount--;
    }
}
