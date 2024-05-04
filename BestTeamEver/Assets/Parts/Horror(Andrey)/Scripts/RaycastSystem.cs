using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastSystem : MonoBehaviour
{
    public Transform RayPoint;
    public float Distation = 2;
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
            if (hit.collider.tag == "Door")
            {
                Info.text = "Door";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Door door = hit.collider.GetComponent<Door>();
                    door.Using();
                }
            }
            else
            {
                Info.text = null;
            }
        }
        else
        {
            Info.text = null;
        }
    }
}
