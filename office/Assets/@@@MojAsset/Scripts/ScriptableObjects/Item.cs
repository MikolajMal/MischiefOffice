using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //Making a blue print for the items

    //new - overwriting definition
    new public string name = "New Item";
    public Sprite icon = null;
    public float timeToSetTheTrap = 10f;

    public virtual void Use()
    {
        //Use item
        //Something might happen

        //Debug.Log("Using " + name);
    }

}
