using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    void Update()
    {
        //ouvrir l'inventaire
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.activeInHierarchy) inventory.SetActive(false);
            else inventory.SetActive(true);
        }
    }
}