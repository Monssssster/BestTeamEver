using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterRay : MonoBehaviour
{
    public Transform RayPoint;
    public float Distation = 5;
    RaycastHit hit;
    public TextMeshProUGUI Info;

    void Update()
    {

        if (Physics.Raycast(RayPoint.position, RayPoint.forward, out hit, Distation))
        {

            if (hit.collider.tag == null)
            {
                Info.text = null;
            }

            if (hit.collider.tag == "Exit")
            {
                Info.text = "Exit";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(4);
                }
            }
        }

        else
        {
            Info.text = null;
        }
    }
}
