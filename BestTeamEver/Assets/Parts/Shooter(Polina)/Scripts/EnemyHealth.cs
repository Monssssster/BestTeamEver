using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HealthValue = 100;
    public Explosion ExplosionPrefab;

    public bool IsAlive()
    {
        return HealthValue > 0;
    }

    public void DealDamage(float Damage)
    {
        HealthValue -= Damage;
        if (HealthValue <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var Explosion = Instantiate(ExplosionPrefab);
        Explosion.transform.position = transform.position;
        KillCounter.KillCount++;
        Destroy(gameObject);
    }
}