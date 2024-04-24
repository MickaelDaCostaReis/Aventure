using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int maxStack = 12;
    public GameObject inventoryItemPrefab; //prefab utilisé pour les collectibles
    public InventorySlot[] inventorySlots; //Liste des slots
    int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)                              //Terrible !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number >=0 && number <= 9)
            {
                ChangeSelectedSlot(number);
            }
        }
    }
    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
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
                itemInSlot.item.stackable== true)
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

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        Collectible itemInSlot = slot.GetComponentInChildren<Collectible>();
        if (itemInSlot != null)
        {
            Item item= itemInSlot.item;
            if (use)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }
}
