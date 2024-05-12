using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NRGBallCaster : MonoBehaviour
{
    public NRGBall NRGBallPrefab;
    public Transform NRGBallSourceTransform;
    public float Delay = 0.35f;
    public float ElapsedTime = 0f;
    //public AudioSource Shoot;
    //public Image NRGBallIcon;

    void Update()
    {
        //UpdateNRGBallIcon();
        ElapsedTime += Time.deltaTime;
        NRGBallCast();
    }
    private void NRGBallCast()
    {
        if (Input.GetMouseButtonDown(0) && ElapsedTime > Delay)
        {
            //Shoot.pitch = Random.Range(0.7f, 1.3f);
            //Shoot.Play();
            ElapsedTime = 0;
            Instantiate(NRGBallPrefab, NRGBallSourceTransform.position, NRGBallSourceTransform.rotation);
        }
    }
    void UpdateNRGBallIcon()
    {
        float fillAmount = ElapsedTime / Delay;
        //NRGBallIcon.fillAmount = fillAmount;
    }
}
