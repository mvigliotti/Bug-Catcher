using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // the size of the inventory
    int inventorySize;

    // the items in the inventory
    List<Item> items;

    public Inventory(int inventorySize)
    {
        this.inventorySize = inventorySize;
        this.items = new List<Item>();
    }

    // add the given GameObject to this inventory
    public void add(GameObject objectToAdd)
    {
        string objectType = objectToAdd.tag; // the type of object that will be added (based on the tag)

        switch(objectType)
        {
            case "Bug":
                Item bugToAdd = new Item(objectToAdd.name, objectToAdd);
                this.items.Add(bugToAdd);
                break;
        }
    }

    // is this inventory full?
    public bool isFull()
    {
        return this.items.Count >= this.inventorySize;
    }

    // how many items are in this inventory?
    public int count()
    {
        return this.items.Count;
    }
}
