using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    public void OpenInventory()
    {
        if (inventory.activeInHierarchy) inventory.SetActive(false);
        else inventory.SetActive(true);
    }
    
}