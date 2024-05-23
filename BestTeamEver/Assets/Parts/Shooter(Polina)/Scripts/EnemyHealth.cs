using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float HealthValue = 100;

    public Animator EnemyAnimator;

    public AudioSource HitSound;

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
        else
        {
            HitSound.pitch = Random.Range(0.5f, 1.3f);
            HitSound.Play();
            EnemyAnimator.SetTrigger("Hit");
        }
    }

    private void Die()
    {
        EnemyAnimator.SetTrigger("Death");
        HitSound.pitch = Random.Range(0.5f, 1.3f);
        HitSound.Play();
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        KillCounter.KillCount++;
    }
}