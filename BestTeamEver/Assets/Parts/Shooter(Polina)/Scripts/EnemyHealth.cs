using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float HealthValue = 100;

    public Animator SkeletonAnimator;
    public Animator SpongeBobAnimator;
    public Animator ElephantAnimator;
    public Animator BananaCatAnimator;

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
            SkeletonAnimator.SetTrigger("Hit");
            SpongeBobAnimator.SetTrigger("Hit");
            ElephantAnimator.SetTrigger("Hit");
            BananaCatAnimator.SetTrigger("Hit");
        }
    }

    private void Die()
    {
        SkeletonAnimator.SetTrigger("Death");
        SpongeBobAnimator.SetTrigger("Death");
        ElephantAnimator.SetTrigger("Death");
        BananaCatAnimator.SetTrigger("Death");
        HitSound.pitch = Random.Range(0.5f, 1.3f);
        HitSound.Play();
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        KillCounter.KillCount++;
    }
}