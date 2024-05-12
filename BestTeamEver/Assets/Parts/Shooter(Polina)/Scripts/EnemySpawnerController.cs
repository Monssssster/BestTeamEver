using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public static int Count;
    public GameObject DoorCloseTrigger;
    void Start()
    {
        ScriptOff();
    }

    private void Update()
    {
        ScriptOn();
    }

    private void ScriptOff()
    {
        GetComponent<EnemySpawner>().enabled = false;
    }

    private void ScriptOn()
    {
        if (Count >= 1 & DoorCloseTrigger != null)
        {
            GetComponent<EnemySpawner>().enabled = true;
        }
    }
}
