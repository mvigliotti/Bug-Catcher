using UnityEngine;

public class Inventory
{
    // the size of the inventory
    int inventorySize;

    // the items in the inventory
    IItem[] items;

    Inventory(int inventorySize, IItem[] items)
    {
        this.inventorySize = inventorySize;
        this.items = items;
    }
}
