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
    public bool FifteenKills = false;
    public bool EnemiesLeft = true;

    public TextMeshProUGUI CountText;

    public AudioSource UnlockSound;
    public AudioSource SkeletonMusic;
    public AudioSource SpongeBobMusic;
    public AudioSource ElephantMusic;
    public AudioSource BananaCatMusic;

    private void Start()
    {
        OffScripts();
        KillCount = 0;
        CountText.text = "Enemies killed: " + KillCount;
    }
    private void Update()
    {
        CountText.text = "Enemies killed: " + KillCount;

        if (KillCount >= 5 && GrenadeIsLocked)
        {
            UnlockGrenade();
        }

        if (KillCount >= 10 && UltimateIsLocked)
        {
            UnlockUltimate();
        }

        if (KillCount >= 15 && !FifteenKills)
        {
            BananaCatMusicPlay();
            FifteenKills = true;
        }

        if (KillCount >= 20 && EnemySpawner != null && EnemiesLeft)
        {
            DestroyEnemySpawner();
        }
    }
    
    private void OffScripts()
    {
        GetComponent<GrenadeCaster>().enabled = false;
        GetComponent<UltimateCaster>().enabled = false;
    }
   
    private void UnlockGrenade()
    {
        GetComponent<GrenadeCaster>().enabled = true;
        GrenadeIsLocked = false;
        UnlockSound.Play();
        SkeletonMusic.Stop();
        SpongeBobMusic.Play();
    }

    private void UnlockUltimate()
    {
        GetComponent<UltimateCaster>().enabled = true;
        UltimateIsLocked = false;
        UnlockSound.Play();
        SpongeBobMusic.Stop();
        ElephantMusic.Play();
    }

    private void BananaCatMusicPlay()
    {
        ElephantMusic.Stop();
        BananaCatMusic.Play();
    }

    private void DestroyEnemySpawner()
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
