using UnityEngine;

public class Item
{
    // the name of the Item
    string itemName;

    // the reference to the GameObject of the Item
    GameObject reference;

    public Item(string itemName, GameObject reference)
    {
        this.itemName = itemName;
        this.reference = reference;
    }
}