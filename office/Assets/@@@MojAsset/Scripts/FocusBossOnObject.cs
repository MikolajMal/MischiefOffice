using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBossOnObject : MonoBehaviour
{
    [Header("Boss ParentGFX Object which should look at this object while interacting")]
    public GameObject bossParentGFX;
    [Header("Checkpoint that activates rotation towards the object")]
    public Transform checkPoint;

    //Zmienna potrzebna aby nie wykonować rotacji bossa do obiektu podczas gdy wykryje on gracza
    bool bossRotated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (bossParentGFX == null)
        {
            Debug.LogError("Nie przypisano poprawnie obiektu Player!  " + this.gameObject.name);
        }
        if (checkPoint == null)
        {
            Debug.LogError("Nie przypisano poprawnie checkpointu!  " + this.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = bossParentGFX.transform.position - checkPoint.transform.position;

        if (distance.magnitude <= 0.3f && bossRotated ==false)
        {
            Vector3 lookAtObject = this.transform.position;
            lookAtObject.y = bossParentGFX.transform.position.y;
            bossParentGFX.transform.LookAt(lookAtObject);

            StartCoroutine(StopRotate());
        }
        else if (distance.magnitude >= 0.5f && bossRotated == true)
        {
            bossRotated = false;
        }
    }

    IEnumerator StopRotate()
    {
        yield return new WaitForSeconds(0.5f);
        bossRotated = true;
    }
}
