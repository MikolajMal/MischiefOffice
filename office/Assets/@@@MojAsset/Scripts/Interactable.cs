using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool interactionAvailable = false;
    protected GameObject interactableObject;


    public void OnTriggerExit(Collider other)
    {
        interactionAvailable = false;
        interactableObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionAvailable = true;
        interactableObject = other.gameObject;
    }

    protected virtual void Interact()
    {

    }
}
