using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            //attribue le drag si le slot est vide
            Collectible collectible = eventData.pointerDrag.GetComponent<Collectible>();
            collectible.parentAfterDrag = transform;
        }
    }
}


