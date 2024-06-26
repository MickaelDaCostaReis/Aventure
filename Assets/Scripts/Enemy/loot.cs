using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float moveSpeed;

    private Item item;

    public void Initialize(Item item)
    {
        this.item = item;
        sr.sprite = item.image;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool canAdd = InventoryManager.instance.AddItem(item);
            if (canAdd)
            {
                StartCoroutine(MoveAndCollect(collision.transform));
            }
        }
    }

    public IEnumerator MoveAndCollect(Transform target)
    {
        while(transform.position!= target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }
        Destroy(gameObject);
    }
}
