using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RaycastSystem : MonoBehaviour
{
    public Transform RayPoint;
    public float Distation = 2;
    public bool KeyIsFound = false;
    public GameObject Monster;
    public GameObject Key;
    RaycastHit hit;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI NeedKey;
    public AudioSource KeyPick;

    void Update()
    {
        if (Physics.Raycast(RayPoint.position, RayPoint.forward, out hit, Distation))
        {
            if (hit.collider.tag == null)
            {
                Info.text = null;
            }
            if (hit.collider.tag == "Key")
            {
                Info.text = "Key";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    KeyPick.Play();
                    Destroy(Key);
                    Destroy(NeedKey);
                    KeyIsFound = true;
                }
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
            if (hit.collider.tag == "Exit")
            {
                Info.text = "Exit";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(3);
                }
            }
            if (hit.collider.tag == "Locked")
            {
                if (!KeyIsFound)
                {
                    Info.text = "Locked";
                }
                if (KeyIsFound)
                {
                    Info.text = "Door";
                }

                if (Input.GetKeyDown(KeyCode.E) && KeyIsFound == false)
                {
                    NeedKey.text = "Need to find the key";
                }
                if (Input.GetKeyDown(KeyCode.E) && KeyIsFound == true)
                {
                    Door door = hit.collider.GetComponent<Door>();
                    door.Using();
                    Invoke(nameof(UnhideMonster), 1);
                    Invoke(nameof(HideMonster), 5);
                }
            }
        }

        else
        {
            Info.text = null;
        }
    }

    private void UnhideMonster()
    {
        Monster.SetActive(true);
    }

    private void HideMonster()
    {
        Destroy(Monster);
    }
}