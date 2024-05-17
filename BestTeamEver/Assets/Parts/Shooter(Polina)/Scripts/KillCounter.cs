using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static int KillCount;
    public GameObject EnemySpawner;
    public GameObject DoorTrigger;
    public TextMeshProUGUI CountText;

    private void Start()
    {
        OffScripts();
        KillCount = 0;
        CountText.text = "Enemies killed: " + KillCount;
    }
    private void Update()
    {
        CountText.text = "Enemies killed: " + KillCount;
        UnlockGrenade();
        DestroyEnemySpawner();
    }
    
    private void OffScripts()
    {
        GetComponent<GrenadeCaster>().enabled = false;
    }
   
    private void UnlockGrenade()
    {
        if (KillCount >= 5)
        {
            GetComponent<GrenadeCaster>().enabled = true;
        }
    }

    private void DestroyEnemySpawner()
    {
        if (KillCount >= 20 & EnemySpawner != null)
        {
            Destroy(EnemySpawner);
            EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
            foreach (EnemyHealth enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            GetComponent<KillCounter>().enabled = false;
            DoorTrigger.SetActive(true);
        }
    }
}
