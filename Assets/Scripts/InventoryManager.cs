using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int maxStack = 12;
    public GameObject inventoryItemPrefab; //prefab utilisé pour les collectibles
    public InventorySlot[] inventorySlots; //Liste des slots

   
    public bool AddItem(Item item)
    {
        //cherche un slot avec le meme item et un nombre inférieur au maximum
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            Collectible itemInSlot = slot.GetComponentInChildren<Collectible>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStack &&
                itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true; // item ajouté
            }
        }

        //cherche un slot vide
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            Collectible itemInSlot = slot.GetComponentInChildren<Collectible>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true; // item ajouté
            }
            
        }
        return false; // inventaire plein
    }
     
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        //crée un gameobject d'item à partir du prefab dans le slot donné
        GameObject newItemGObject = Instantiate(inventoryItemPrefab, slot.transform); 
        Collectible collectible = newItemGObject.GetComponent<Collectible>();
        collectible.InitialiseItem(item);
    }

}
