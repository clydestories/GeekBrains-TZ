using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _viewAngle;
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _patrolingSpeed;
    [SerializeField] private float _chasingSpeed;

    private NavMeshAgent _agent;
    private bool _canMove = true;

    public float ChasingSpeed => _chasingSpeed;
    public float PatrolingSpeed => _patrolingSpeed;
    public float MaxSpeed => _chasingSpeed;

    public bool IsPlayerSeen
    {
        get
        {
            Vector3 direction = _player.transform.position - transform.position;

            if (Vector3.Angle(direction, transform.forward) < _viewAngle)
            {
                if (Vector3.Distance(_player.transform.position, transform.position) < _viewDistance)
                {
                    if (Physics.Raycast(transform.position, direction, out RaycastHit hit))
                    {
                        if (hit.collider.gameObject.TryGetComponent(out Player _))
                        {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Construct(Player player, List<Transform> points)
    {
        _player = player;
        _patrolPoints = points.ToList();
    }

    public void ChasePlayer()
    {
        if (_canMove)
        {
            _agent.speed = _chasingSpeed;
            _agent.SetDestination(_player.transform.position);
        }
    }

    public void Patrol()
    {
        if (_canMove)
        {
            _agent.speed = _patrolingSpeed;

            if (Vector3.Distance(transform.position, _agent.steeringTarget) < _stoppingDistance)
            {
                SetNewPatrolPoint();
            }
        }
    }

    public void Stop()
    {
        _agent.speed = 0;
        _canMove = false;
    }

    public void StartMoving()
    {
        _canMove = true;
    }

    private void SetNewPatrolPoint()
    {
        _agent.SetDestination(_patrolPoints[Random.Range(0, _patrolPoints.Count)].position);
    }
}
