using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWindow : Interactable
{
    public Text myText;
    public GameObject myDisplay;
    public Camera myCamera;
    public float fadeTime;


    public Item item;
    public InteractableObject interactableObj;



    // Start is called before the first frame update
    void Start()
    {
        //myText - przypisany w inspektorze
        //myPanel - przypisany w inspektorze
        //myCamera - przypisane w inspektorze

        ChooseTypeOfObject();

        myText.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {

        FadeText();
    }

    void FadeText()
    {
        if(interactionAvailable)
        {
            myDisplay.SetActive(true);
            myDisplay.transform.forward = myCamera.transform.forward;
            //myText.text = "Pick up: " + actualObjectName;
            myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            myDisplay.SetActive(false);
        }
    }

    void ChooseTypeOfObject()
    {
        if (item != null)
        {
            myText.text = "Pick up: " + item.name;
        }
        if (interactableObj != null)
        {
            CooseTypeOfInteractableObject();
        }

        if (item != null && interactableObj != null)
        {
            Debug.LogError("Here can not be two type of objects!!! (InteractionWindow script) :" + this.name);
        }
    }

    void CooseTypeOfInteractableObject()
    {
        switch (interactableObj.type)
        {
            case InteractableObject.TypeOfInteractableObject.None:
                myText.text = "Do nothing with: " + interactableObj.name;
                break;
            case InteractableObject.TypeOfInteractableObject.Door:
                myText.text = "Open the door.";
                break;
            case InteractableObject.TypeOfInteractableObject.Locker:
                myText.text = "Open: " + interactableObj.name;
                break;
            case InteractableObject.TypeOfInteractableObject.Machine:
                myText.text = "Interact with: " + interactableObj.name;
                break;
            case InteractableObject.TypeOfInteractableObject.Trap:
                myText.text = /*"Set a trap: " +*/ interactableObj.name;
                break;
            case InteractableObject.TypeOfInteractableObject.Hideout:
                myText.text = "Hide: " + interactableObj.name;
                break;
            default:
                myText.text = "Błędne przypisanie typu objektu";
                break;
        }
    }
}
