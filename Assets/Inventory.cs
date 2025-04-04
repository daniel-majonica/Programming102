using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<CollectableItem> CollectableItems = new List<CollectableItem>();
    public int InventorySize = 10;

    public bool AddItem(CollectableItem item)
    {
        if (CollectableItems.Count < InventorySize)
        {
            CollectableItems.Add(item);
            Debug.Log("added Item");
        }
        else
        {
            return false;
        }
        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log(InventoryToString());
        }
    }

    public string InventoryToString()
    {
        string name = "Inventory: ";
        foreach (var item in CollectableItems)
        {
            name += item.ItemName + " | ";
        }
        return name;
    }
}
