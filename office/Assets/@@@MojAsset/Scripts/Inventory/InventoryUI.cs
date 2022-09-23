using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    //tablica slotów do przeszukiwania
    InventorySlot[] slots;

    //zmienne pomocnicze do wyboru elementu
    public int indexSelectionActual = -1;
    public int indexSelectionNew = -1;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //Count daje długość listy. Jeżeli jet ona równa 0 to i jest równe a nie mniejsze niż zero i slot się czyści
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void UpdateSelection()
    {
        if (indexSelectionActual == -1)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].isSlected)
                {
                    indexSelectionActual = i;
                    Debug.Log("Przypisanie actual selection");
                }
            }
        }
        else if (indexSelectionActual != -1)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i != indexSelectionActual && slots[i].isSlected)
                {
                    indexSelectionNew = i;
                }
            }

            if (indexSelectionNew > -1)
            {
                slots[indexSelectionActual].SelectItem();
                indexSelectionActual = indexSelectionNew;
                indexSelectionNew = -1;
            }
            else if (indexSelectionNew == -1)
            {
                indexSelectionActual = -1;
            }
        }
    }
}
