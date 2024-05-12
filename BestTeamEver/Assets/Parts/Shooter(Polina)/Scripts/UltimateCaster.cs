using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateCaster : MonoBehaviour
{
    public GameObject HexEffectPrefab;
    public GameObject Gear;
    public Image SpellIcon;
    public float Cooldown = 10f;
    public AudioSource UltimateSound;

    float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        UpdateUltimateIcon();

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
            Instantiate(Gear, enemy.transform.position, enemy.transform.rotation);
        }
        KillCounter.KillCount += 2;
        UltimateSound.Play();
        _timer = 0;
    }

    void UpdateUltimateIcon()
    {
        float fillAmount = _timer / Cooldown;
        SpellIcon.fillAmount = fillAmount;
    }
}