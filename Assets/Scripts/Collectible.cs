using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Collectible : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Item item;
    [Header("UI")]
    public Image img;
    
    public void InitialiseItem()
    public void OnBeginDrag(PointerEventData eventData)
    {
        img.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        img.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
