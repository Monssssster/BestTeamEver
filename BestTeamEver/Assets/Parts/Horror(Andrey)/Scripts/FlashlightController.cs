using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private bool _flashligthActive = false;
    public GameObject Flashlight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashlightSwitch();
        }
    }

    void FlashlightSwitch()
    {
        if (_flashligthActive)
        {
            Flashlight.SetActive(false);
            _flashligthActive = false;
        }
        else
        {
            Flashlight.SetActive(true);
            _flashligthActive = true;
        }
    }
}
