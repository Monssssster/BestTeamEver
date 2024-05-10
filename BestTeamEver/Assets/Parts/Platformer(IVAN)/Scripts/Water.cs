using UnityEngine;

public class Water : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = SpawnPoint.transform.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
