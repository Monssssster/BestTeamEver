using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    public GameObject Door;
    public Transform Player;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = other.transform.position;
            Door door = Door.GetComponent<Door>();
            door.Using();
            Destroy(gameObject);
        }
    }
}
