using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayerOnObject : Interactable
{
    [Header("Player Object which should look at this object while interacting")]
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Debug.LogError("Nie przypisano poprawnie obiektu Player!  " + this.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionAvailable)
        {
            if (this.gameObject.tag=="Trap" && Input.GetKeyDown(KeyCode.Z))
            {
                Vector3 lookAtTrap = this.transform.position;
                lookAtTrap.y = Player.transform.position.y;
                Player.transform.LookAt(lookAtTrap);
            }
            else if (this.gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.E))
            {
                Vector3 lookAtTrap = this.transform.position;
                lookAtTrap.y = Player.transform.position.y;
                Player.transform.LookAt(lookAtTrap);
            }
        }


    }
}
