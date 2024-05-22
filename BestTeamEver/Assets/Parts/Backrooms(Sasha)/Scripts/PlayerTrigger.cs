using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public int ItemCount = 0;
    public AudioSource BoxPickup;

    public TextMeshProUGUI Counter;

    private void Start()
    {
        Counter.text = "Boxes collected: " + ItemCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            BoxPickup.pitch = Random.Range(0.7f, 1f);
            BoxPickup.Play();
            ItemCount++;
            Counter.text = "Boxes collected: " + ItemCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "Exit" && ItemCount == 10)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}
