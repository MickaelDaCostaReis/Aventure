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
}
