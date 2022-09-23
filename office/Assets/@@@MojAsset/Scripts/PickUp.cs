using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    bool interactionStarted = false;

    public Item item;

    public Animator playerAnimator;

    void Update()
    {
        Interact();
    }

    protected override void Interact()
    {
        base.Interact();

        if (interactionAvailable)
        {
            if (Input.GetKeyDown(KeyCode.E) && !interactionStarted)
            {
                playerAnimator.SetTrigger("pickingDown");
                interactionStarted = true;
            }
            if (PlayerAnimationManager.isItemPicked == true)
            {
                AddToInventory();
                PlayerAnimationManager.isItemPicked = false;
                interactionStarted = false;
            }
        }

    }

    void AddToInventory()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
