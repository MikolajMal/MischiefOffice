using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// Tworzymy to aby nie musieć robić FindObjectOfType<> więc robimy statyczną instancję tej klasy
    /// </summary>
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            //We triggering the event - wywołujemy event
            onItemChangedCallback.Invoke();
        }

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            //We triggering the event - wywołujemy event
            onItemChangedCallback.Invoke();
        }
    }
}
