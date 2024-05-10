using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Damage = 15;

    private void Start()
    {
        Invoke("DestroyFireball", LifeTime);
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
        DestroyFireball();
    }

    private void DamageEnemy(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(Damage);
        }
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}