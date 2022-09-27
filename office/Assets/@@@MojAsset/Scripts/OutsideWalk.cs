using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideWalk : MonoBehaviour
{
    public float speed;
    public float speedRotation;

    public Transform[] checkPoints;
    int actualCheckPoint;

    private void Start()
    {
        actualCheckPoint = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkPoints[actualCheckPoint].position, speed * Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation(transform.position - checkPoints[actualCheckPoint].position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speedRotation * Time.deltaTime);

        if (Vector3.Distance(transform.position,checkPoints[actualCheckPoint].position) < 0.2f)
        {
            actualCheckPoint++;
            if (actualCheckPoint>=checkPoints.Length)
            {
                actualCheckPoint = 0;
            }
        }
    }
}
