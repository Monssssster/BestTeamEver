using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public List<Transform> TPoints;
    public PlayerController Player;
    public GameObject BlackScreen;

    public float ViewAngle;

    public AudioSource CatchSound;
    public AudioSource MonsterSound;
    public AudioSource Emb;

    private NavMeshAgent _agent;
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
    }

    private void Components()
    {
        _agent = GetComponent<NavMeshAgent>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<CameraRotate>().enabled = false;
            MonsterSound.Stop();
            Emb.Stop();
            CatchSound.Play();
            BlackScreen.SetActive(true);
            Invoke("Restart", 2);
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _agent.destination = Player.transform.position;
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(2);
    }

    private void NotiecePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;

        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 0.6f, 0), direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                    print("Player Noticed");
                }
            }
        }
    }
}
