using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDialogue : MonoBehaviour
{
    public GameObject Dialogue;

    public GameObject InGameUI;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<PlayerController>().enabled = true;
            GetComponent<CameraRotate>().enabled = true;
            InGameUI.SetActive(true);
            Dialogue.SetActive(false);
            GetComponent<HideDialogue>().enabled = false;
        }
    }
}
