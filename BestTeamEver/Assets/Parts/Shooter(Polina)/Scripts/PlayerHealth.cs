using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float HealthValue = 100;
    public RectTransform ValueRectTransform;
    //public GameObject InGameUI;
    //public GameObject GameOverScreen;
    //public AudioSource LoseSound;

    private float _maxValue;

    private void Start()
    {
        _maxValue = HealthValue;
        DrawHealthBar();
    }
    public void DealDamage(float Damage)
    {
        HealthValue -= Damage;
        if (HealthValue <= 0)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }

    public void PlayerIsDead()
    {
        //InGameUI.SetActive(false);
        //GameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotate>().enabled = false;
        GetComponent<NRGBallCaster>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<GrenadeCaster>().enabled = false;
        GetComponent<UltimateCaster>().enabled = false;

        //LoseSound.Play();
    }
    public void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(HealthValue / _maxValue, 1);
    }

    public void AddHealth(float amount)
    {
        HealthValue += amount;
        HealthValue = Mathf.Clamp(HealthValue, 0, _maxValue);
        DrawHealthBar();
    }
}