using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : Interactable
{
    Animator doorAnimator;

    public static bool isDoorOpen;


    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("isDoorOpen", false);
        isDoorOpen = false;
    }

    void Update()
    {
        DoorManagement();
    }

    private void DoorManagement()
    {
        if (interactionAvailable&&Input.GetKeyDown(KeyCode.E))
        {
            if (!isDoorOpen)
            {
                doorAnimator.SetBool("isDoorOpen", true);
                isDoorOpen = true;
            }
            else if (isDoorOpen)
            {
                doorAnimator.SetBool("isDoorOpen", false);
                isDoorOpen = false;
            }
        }
    }
}
