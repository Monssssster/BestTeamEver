using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateCaster : MonoBehaviour
{
    public GameObject HexEffectPrefab;
    public GameObject Skull;
    public float Cooldown = 10f;
    public AudioSource UltimateSound;

    float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _timer >= Cooldown)
        {
            CastHex();
        }
    }

    void CastHex()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            Destroy(enemy.gameObject);
            Instantiate(HexEffectPrefab, enemy.transform.position, Quaternion.identity);
            Instantiate(Skull, enemy.transform.position, enemy.transform.rotation);
        }
        KillCounter.KillCount += 2;
        UltimateSound.Play();
        _timer = 0;
    }
}