using UnityEngine;

public class Water : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = SpawnPoint.transform.position;
        }
    }
}
