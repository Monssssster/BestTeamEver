using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    public float HealAmount = 50;
    private void OnTriggerEnter(Collider other)
    {
        var playerHeath = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHeath != null)
        {
            playerHeath.AddHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
