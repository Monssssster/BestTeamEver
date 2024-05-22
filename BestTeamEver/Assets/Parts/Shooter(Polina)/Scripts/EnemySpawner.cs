using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI EnemyPrefab;
    public PlayerController Player;
    public List<Transform> TPoints;
    public List<EnemyAI> _enemies;

    public int EnemiesMaxCount = 1;
    public float SpawnDelay = 5;
    public float IncreaseEnemiesCountDelay = 30;

    private List<Transform> _spawnerPoints;

    private float _timeLastSpawned;

    public void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>().ToList());
        _enemies = new List<EnemyAI>();
        Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountDelay);
    }

    private void IncreaseEnemiesMaxCount()
    {
        EnemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountDelay);
    }

    private void Update()
    {
        CheckForDeadEnemies();
        
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        if (_enemies.Count >= EnemiesMaxCount)
        {
            return;
        }
        if (Time.time - _timeLastSpawned < SpawnDelay)
        {
            return;
        }

        var Enemy = Instantiate(EnemyPrefab, _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position, Quaternion.identity);
        Enemy.Player = Player;
        Enemy.TPoints = TPoints;
        _enemies.Add(Enemy);
        _timeLastSpawned = Time.time;
    }

    private void CheckForDeadEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            Destroy(_enemies[i].gameObject);
            _enemies.RemoveAt(i);
            i--;
        }
    }
}
