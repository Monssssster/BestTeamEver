using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public Grenade GrenadePrefab;
    public float ForceMin = 300;
    public float ForceMax = 500;
    public float DelayMin = 2.5f;
    public float DelayMax = 4;
    public AudioSource GrenadeShoot;

    private void Start()
    {
        Invoke("SpawnGrenade", Random.Range(DelayMin, DelayMax));
    }

    private void SpawnGrenade()
    {
        var Grenade = Instantiate(GrenadePrefab);
        var direction = Random.onUnitSphere;

        Grenade.transform.position = transform.position;
        Grenade.GetComponent<Rigidbody>().AddForce(direction * Random.Range(ForceMin,ForceMax));
        
        Invoke("SpawnGrenade", Random.Range(DelayMin, DelayMax));
        GrenadeShoot.pitch = Random.Range(0.5f, 1f);    
        GrenadeShoot.Play();
    }
}
