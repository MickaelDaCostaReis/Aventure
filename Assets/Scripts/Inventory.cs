using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject inventory;

    void Update()
    {
        if (!inventory.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(false);
        }

    }
}