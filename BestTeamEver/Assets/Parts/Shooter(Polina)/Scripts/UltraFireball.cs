using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraFireball : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Damage = 100;
    public GameObject ExplosionPrefab;

    private void Start()
    {
        Invoke("DestroyNRGBall", LifeTime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyNRGBall();
    }

    private void DamageEnemy(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(Damage);
        }
    }

    private void DestroyNRGBall()
    {
        Explose();
        Destroy(gameObject);

    }

    private void Explose()
    {
        Destroy(gameObject);
        var Exp = Instantiate(ExplosionPrefab);
        Exp.transform.position = transform.position;
    }
}
