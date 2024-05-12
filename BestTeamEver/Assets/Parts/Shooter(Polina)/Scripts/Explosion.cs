using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float MaxSize = 5;
    public float Speed = 7;
    public float DamageEnemy = 60;
    public float DamagePlayer = 30;
    //public AudioSource Exp;
    void Start()
    {
        transform.localScale = Vector3.zero;
        //Exp.pitch = Random.Range(0.5f, 1f);
        //Exp.Play(); 
    }

    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;

        if (transform.localScale.y > MaxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(DamagePlayer);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(DamageEnemy);
        }
    }
}