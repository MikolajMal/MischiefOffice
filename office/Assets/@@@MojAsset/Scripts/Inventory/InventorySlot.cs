using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public float r, g, b;

    [HideInInspector]
    public Item item;

    public bool isSlected = false;


    private void Update()
    {

    }

    //przypisujemy konkretny ScriptableObject do tego slotu żeby móc kożystać np. z ikony
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void SelectItem()
    {
        if (item != null)
        {
            var colors = GetComponentInChildren<Button>().colors;

            if (!isSlected)
            {
                colors.normalColor = new Color(0.3f, 0.3f, 0.3f, 255f);
                colors.highlightedColor = new Color(0.4f, 0.4f, 0.4f, 255f); ;
                isSlected = true;
            }
            else if (isSlected)
            {
                colors.normalColor = Color.white;
                colors.highlightedColor = Color.gray;
                isSlected = false;
            }

            GetComponentInChildren<Button>().colors = colors;
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    //używanie itemu
    public void UseItem()
    {

        if (item != null && isSlected)
        {
            //Należy odwybrać item
            Debug.Log("Wywolanie UseItem()");
            SelectItem();
            Inventory.instance.Remove(item);
            //item.Use();
        }


    }


}
