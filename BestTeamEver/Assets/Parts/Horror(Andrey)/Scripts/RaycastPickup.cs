using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPickup : MonoBehaviour
{
    //������ �� ������, ������� ������������
    Rigidbody _target = null;
    bool _isLocked = false;

    void Update()
    {
        //���� ����� ��� �� ������������� ������
        if (!_isLocked)
        {
            //���� ������ ����� ������ ����
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //������� ��� ����� ����� ������
                if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
                {
                    //���� ��� ����� � ������ � ����������� Rigidbody
                    if (hit.rigidbody != null && hit.collider.tag == "Block-Unlock")
                    {
                        //��������� ������
                        LockOnTarget(hit.rigidbody);
                    }
                }
            }
        }
        else
        {
            //���� ���� ��������������� ������, ���������� ������ � ����� ����� ������ ����
            _target.transform.position = transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                //���� ������ ����� ������ ����, ��������� ������
                ReleaseTarget();
            }
        }

    }

    void LockOnTarget(Rigidbody target)
    {
        //���������� ����� ������ ������������
        _target = target;
        //��������� ������ � �������
        _target.isKinematic = true;
        //���������� ������ � ����� �����
        _target.transform.position = transform.position;
        _isLocked = true;
    }

    void ReleaseTarget()
    {
        //�������� ������ � �������
        _target.isKinematic = true;
        //�������� ������ �� ������
        _target.velocity = transform.forward * 10;
        _target = null;
        _isLocked = false;
    }
}
