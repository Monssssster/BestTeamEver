using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPickup : MonoBehaviour
{
    //ссылка на объект, который зафиксирован
    Rigidbody _target = null;
    bool _isLocked = false;

    void Update()
    {
        //если пушка еще не зафиксировала объект
        if (!_isLocked)
        {
            //если нажата левая кнопка мыши
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //пускаем луч через центр экрана
                if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
                {
                    //если луч попал в объект с компонентом Rigidbody
                    if (hit.rigidbody != null && hit.collider.tag == "Block-Unlock")
                    {
                        //фиксируем объект
                        LockOnTarget(hit.rigidbody);
                    }
                }
            }
        }
        else
        {
            //если есть зафиксированный объект, перемещаем объект в точку пушки каждый кадр
            _target.transform.position = transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                //если нажата левая кнопка мыши, отпускаем объект
                ReleaseTarget();
            }
        }

    }

    void LockOnTarget(Rigidbody target)
    {
        //запоминаем какой объект зафиксирован
        _target = target;
        //отключаем физику у объекта
        _target.isKinematic = true;
        //перемещаем объект в точку пушки
        _target.transform.position = transform.position;
        _isLocked = true;
    }

    void ReleaseTarget()
    {
        //включаем физику у объекта
        _target.isKinematic = true;
        //обнуляем ссылку на объект
        _target.velocity = transform.forward * 10;
        _target = null;
        _isLocked = false;
    }
}
