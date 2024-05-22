using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;
    public float Force = 2000;
    public float Delay = 5.0f;
    public float ElapsedTime = 0.0f;
    //public AudioSource GrenadeShoot;
    //public Image GrenadeIcon;
    void Update()
    {
        //UpdateGrenadeIcon();
        ElapsedTime += Time.deltaTime;
        GrenadeCast();
    }
    private void GrenadeCast()
    {
        if (Input.GetMouseButtonDown(1) && ElapsedTime > Delay && Time.timeScale != 0)
        {
            //GrenadeShoot.pitch = Random.Range(0.7f, 1.3f);
            //GrenadeShoot.Play();
            ElapsedTime = 0.0f;
            var Grenade = Instantiate(GrenadePrefab);
            Grenade.transform.position = GrenadeSourceTransform.position;
            Grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * Force);
        }
    }
    void UpdateGrenadeIcon()
    {
        float fillAmount = ElapsedTime / Delay;
        //GrenadeIcon.fillAmount = fillAmount;
    }
}
