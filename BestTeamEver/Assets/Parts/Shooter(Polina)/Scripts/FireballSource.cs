using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform TargetPoint;
    public Camera CameraLink;
    public float TargetInSkyDistance;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TargetPoint.position = hit.point;
        }
        else
        {
            TargetPoint.position = ray.GetPoint(TargetInSkyDistance);
        }
        transform.LookAt(TargetPoint.position);
    }
}