using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerOpening : Interactable
{
    //Zmienne dla animacji/otwierania
    Animator lockerAnimator;
    bool isDrawerOpen = false;

    //Zmienne dla wyświetlania przedmiotu
    [Header("Object which will appear")]
    public GameObject trapGFX;
    public GameObject trapDisplay;
    InteractionWindow interactionWindow;
    PickUp pickUpScript;



    private void Start()
    {
        lockerAnimator = GetComponent<Animator>();
        if (trapGFX != null && trapDisplay != null)
        {
            trapGFX.SetActive(false);
            trapDisplay.SetActive(false);
            interactionWindow = GetComponentInChildren<InteractionWindow>();
            pickUpScript = GetComponentInChildren<PickUp>();
            interactionWindow.enabled = false;
            pickUpScript.enabled = false;
        }
    }

    void Update()
    {
        LockerOpen();
    }


    void LockerOpen()
    {
        if (interactionAvailable && Input.GetKeyDown(KeyCode.Q))
        {
            if (!isDrawerOpen)
            {
                lockerAnimator.SetBool("LockerOpen", true);
            }
            else
            {
                lockerAnimator.SetBool("LockerOpen", false);
            }

            isDrawerOpen = !isDrawerOpen;

        }
    }



    /// <summary>
    /// Chowanie i wyświetlanie tylko grafiki obiektu do pułapki
    /// </summary>
    void DisplayMeshTrapObject()
    {
        if (trapGFX != null)
        {
            trapGFX.SetActive(true);
        }
    }

    void HideMeshTrapObject()
    {
        if (trapGFX != null)
        {
            trapGFX.SetActive(false);
        }
    }

    /// <summary>
    /// Chowanie i pokzywanie obiektu do interakcji
    /// </summary>
    void ShowDisplayTrapObject()
    {
        if (trapDisplay != null)
        {
            interactionWindow.enabled = true;
            pickUpScript.enabled = true;
            trapDisplay.SetActive(true);
        }
    }

    void HideDisplayTrapObject()
    {
        if (trapDisplay != null)
        {
            interactionWindow.enabled = false;
            pickUpScript.enabled = false;
            trapDisplay.SetActive(false);
        }
    }

}
