using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private EnemyTracker _tracker;
    [SerializeField] private Player _player;
    [SerializeField] private int _capacity;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<Transform> _points;

    private Coroutine _spawning;

    private void Start()
    {
        if (_spawning != null)
        {
            StopCoroutine(_spawning);
        }

        _spawning = StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_capacity > 0)
        {
            yield return wait;
            Spawn();
        }

        _spawning = null;
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, transform.position, transform.rotation);
        enemy.Construct(_player, _points);
        _capacity--;
        _tracker.AddEnemyCount();
        enemy.Died += _tracker.RemoveEnemyCount;
    }
}
