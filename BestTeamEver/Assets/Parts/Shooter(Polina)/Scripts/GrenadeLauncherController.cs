using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherController : MonoBehaviour
{
    public static int Count;
    public GameObject DoorCloseTrigger;
    void Awake()
    {
        ScriptOff();
    }

    private void Update()
    {
        ScriptOn();
    }

    private void ScriptOff()
    {
        GetComponent<GrenadeLauncher>().enabled = false;
    }

    private void ScriptOn()
    {
        if (Count >= 1 & DoorCloseTrigger != null)
        {
            GetComponent<GrenadeLauncher>().enabled = true;
        }
    }
}
