using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HealthValue = 100;

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
        KillCounter.KillCount++;
        Destroy(gameObject);
    }
}