using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitSpawner : MonoBehaviour
{
    public float DeelayMin = 30;
    public float DelayMax = 60;
    public AidKit AidKitPrefab;
    private AidKit _aidKit;

    private void Update()
    {
        if (_aidKit != null)
        {
            return;
        }
        if (IsInvoking())
        {
            return;
        }
        Invoke("CreateAidKit", Random.Range(DeelayMin,DelayMax));
    }
    private void CreateAidKit()
    {
        _aidKit = Instantiate(AidKitPrefab);
        _aidKit.transform.position = transform.position;
    }
}
