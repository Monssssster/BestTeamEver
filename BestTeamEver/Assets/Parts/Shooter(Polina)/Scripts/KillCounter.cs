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

    public bool GrenadeIsLocked = true;
    public bool UltimateIsLocked = true;
    public bool EnemiesLeft = true;

    public TextMeshProUGUI CountText;

    public AudioSource UnlockSound;

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
        UnlockUltimate();
        DestroyEnemySpawner();
    }
    
    private void OffScripts()
    {
        GetComponent<GrenadeCaster>().enabled = false;
    }
   
    private void UnlockGrenade()
    {
        if (KillCount >= 5 && GrenadeIsLocked)
        {
            GetComponent<GrenadeCaster>().enabled = true;
            GrenadeIsLocked = false;
            UnlockSound.Play();
        }
    }

    private void UnlockUltimate()
    {
        if (KillCount >= 10 && UltimateIsLocked)
        {
            GetComponent<UltimateCaster>().enabled = true;
            UltimateIsLocked = false;
            UnlockSound.Play();
        }
    }

    private void DestroyEnemySpawner()
    {
        if (KillCount >= 20 && EnemySpawner != null && EnemiesLeft)
        {
            Destroy(EnemySpawner);
            EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
            foreach (EnemyHealth enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            GetComponent<KillCounter>().enabled = false;
            DoorTrigger.SetActive(true);
            EnemiesLeft = false;
        }
    }
}
