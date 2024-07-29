using System.Collections;
using UnityEngine;

public class BruiserEnemy : Enemy
{
    [SerializeField] private float _rageDelay;
    [SerializeField] private float _rageHeal;

    private Coroutine _rage;

    private void OnEnable()
    {
        SubscribeListeners();
        EventHandler.Healed += ContinueMoving;
    }

    private void Start()
    {
        if (_rage != null)
        {
            StopCoroutine(_rage);
        }

        _rage = StartCoroutine(Rage());
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
        EventHandler.Healed -= ContinueMoving;
    }

    private IEnumerator Rage()
    {
        var wait = new WaitForSeconds(_rageDelay);

        while (enabled)
        {
            yield return wait;
            Heal();
        }

        _rage = null;
    }

    private void Heal()
    {
        EnemyMover.Stop();
        Health.Heal(_rageHeal);
        Animator.StartHealAnimation();
    }

    private void ContinueMoving()
    {
        EnemyMover.StartMoving();
    }
}
