using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarBillboard : MonoBehaviour
{
    public Transform cam;

    //LateUpdate żeby obrót billboardu był po ruchu kamery aby nie było dziwnych rakcji billboardu
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
