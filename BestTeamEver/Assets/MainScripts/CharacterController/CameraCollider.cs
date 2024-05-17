using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public Transform CameraAxis;
    public float Distance = 3;

    // Update is called once per frame
    void Update()
    {
        var ray = (transform.position - CameraAxis.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(CameraAxis.position, ray, out hit, Distance))
        {
            if (hit.collider.gameObject)
            {
                transform.position = hit.point;
            }
        }
        else
        {
            transform.position = CameraAxis.position + ray * Distance;
        }
    }
}
