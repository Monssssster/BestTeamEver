using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static int KillCount;
    public GameObject LockGrenade;
    public GameObject LockUltimate;
    public GameObject EnemySpawner;
    public GameObject GrenadeSpawners;
    public GameObject Bowl;
    public GameObject BowlPlace;
    public TextMeshProUGUI CountText;
    public AudioSource Unlock;

    private void Start()
    {
        OffScripts();
    }
    private void Update()
    {
        CountText.text = KillCount.ToString();
        UnlockGrenade();
        UnlockUltimate();
        DestroyEnemySpawner();
    }
    
    private void OffScripts()
    {
        GetComponent<GrenadeCaster>().enabled = false;
        GetComponent<UltimateCaster>().enabled = false;
    }
   
    private void UnlockGrenade()
    {
        if (KillCount >= 5 & LockGrenade != null)
        {
            Unlock.Play();
            Destroy(LockGrenade);
            GetComponent<GrenadeCaster>().enabled = true;
        }
    }

    private void UnlockUltimate()
    {
        if (KillCount >= 10 & LockUltimate != null)
        {
            Unlock.Play();
            Destroy(LockUltimate);
            GetComponent<UltimateCaster>().enabled = true;
        }
    }

    private void DestroyEnemySpawner()
    {
        if (KillCount >= 20 & EnemySpawner != null)
        {
            Unlock.Play();
            Destroy(EnemySpawner);
            Destroy(GrenadeSpawners);
            Bowl.transform.position = BowlPlace.transform.position;
            GetComponent<KillCounter>().enabled = false;
        }
    }
}
