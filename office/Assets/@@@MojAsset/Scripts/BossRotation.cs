using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    public Transform[] _checkPoints;

    int _actualCheckPoint;

    float rotationSpeed = 10f;

    bool checkPointUpdated;

    //Vector3 dir;

    private void Start()
    {
        _actualCheckPoint = 0;
        checkPointUpdated = false;
    }


    void Update()
    {
        Vector3 dir = _checkPoints[_actualCheckPoint].position - transform.position;
        //dir = new Vector3(0, _checkPoints[_actualCheckPoint].position.y - transform.position.y, 0);
        if (!BossMovement.checkPointAchieved)
        {
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            checkPointUpdated = false;
        }
        else if (!checkPointUpdated)
        {
            if (_checkPoints.Length - 1 > _actualCheckPoint)
            {
                _actualCheckPoint++;
            }
            else
            {
                _actualCheckPoint = 0;
            }

            checkPointUpdated = true;

        }


    }
}
