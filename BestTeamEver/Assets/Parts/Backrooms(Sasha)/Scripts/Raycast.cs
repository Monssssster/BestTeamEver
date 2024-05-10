using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public Transform RayPoint;
    public float Distation = 2;
    public int ItemCount = 0;
    RaycastHit hit;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI Counter;

    private void Start()
    {
        Counter.text = "Cubes collected " + ItemCount;
    }

    void Update()
    {

        if (Physics.Raycast(RayPoint.position, RayPoint.forward, out hit, Distation))
        {

            if (hit.collider.tag == null)
            {
                Info.text = null;
            }
            
            if (hit.collider.tag == "Cube")
            {
                Info.text = "Cube";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ItemCount++;
                    Counter.text = "Cubes collected: " + ItemCount;
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hit.collider.tag == "Exit")
            {
                Info.text = "Exit";

                if (Input.GetKeyDown(KeyCode.E) && ItemCount == 5)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        else
        {
            Info.text = null;
        }
    }
}
