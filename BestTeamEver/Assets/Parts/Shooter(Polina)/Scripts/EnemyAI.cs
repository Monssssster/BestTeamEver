
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> TPoints;
    public PlayerController Player;
    public float ViewAngle;
    public float Damage = 30;

    private NavMeshAgent _agent;
    private PlayerHealth _playerHealth;
    private bool _isPlayerNoticed;

    void Start()
    {
        Components();
    }


    void Update()
    {
        NotiecePlayerUpdate();
        ChaseUpdate();
        PatrolUnpade();
        AttackUpdate();
    }

    private void Components()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }

    private void PatrolUnpade()
    {
        if (_isPlayerNoticed == false)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                PickNewPoint();
            }
        }
    }

    private void PickNewPoint()
    {
        _agent.SetDestination(TPoints[Random.Range(0, TPoints.Count)].position);
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _agent.destination = Player.transform.position;
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed == true)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _playerHealth.DealDamage(Damage * Time.deltaTime);
            }
        }
    }

    private void NotiecePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

}