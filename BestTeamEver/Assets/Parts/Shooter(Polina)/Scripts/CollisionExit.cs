using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Exit")
        {
            SceneManager.LoadScene(4);
        }
    }
}
