using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptfortesting : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] toPickup;


    public void PickupItems(int id)
    {
        bool result=inventoryManager.AddItem(toPickup[id]);
        if (result) Debug.Log("item added");
        else Debug.Log("Inventory full");
    }
    public void GetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("received item"+ receivedItem);
        }   
        else
        {
            Debug.Log("No item received");
        }
    }
    public void UseGetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("used item" + receivedItem);
        }
        else
        {
            Debug.Log("No item used");
        }
    }
}
