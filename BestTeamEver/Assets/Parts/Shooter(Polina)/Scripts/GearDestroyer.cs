using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearDestroyer : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 5);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
