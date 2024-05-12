using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public static int End;
    public GameObject InGameUI;
    public GameObject TheEndScreen;
    public AudioSource TheEndAudio;

    private void Update()
    {
        EndOfTheGame();
    }

    private void EndOfTheGame()
    {
        if (End >= 1)
        {
            InGameUI.SetActive(false);
            TheEndScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraRotate>().enabled = false;
            GetComponent<NRGBallCaster>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<GrenadeCaster>().enabled = false;
            GetComponent<UltimateCaster>().enabled = false;
            TheEndAudio.Play();
        }
    }
}
