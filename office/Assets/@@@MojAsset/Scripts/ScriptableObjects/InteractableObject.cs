using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InteractableObject", menuName = "Environment/InteractableObject")]
public class InteractableObject : ScriptableObject
{

    //Making a blue print for the interactable objects

    //new - overwriting definition
    new public string name = "New InteractableObject";

    public enum TypeOfInteractableObject { None, Door, Locker, Machine, Trap, Hideout };

    public TypeOfInteractableObject type = TypeOfInteractableObject.None;
}
