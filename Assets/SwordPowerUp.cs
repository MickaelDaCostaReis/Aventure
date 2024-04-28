using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SwordPowerUp : MonoBehaviour
{
    [SerializeField] GameObject setOn;
    [SerializeField] Item sword;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool canAdd = InventoryManager.instance.AddItem(sword);
            if (canAdd)
            {
                setOn.SetActive(true);
                StartCoroutine(MoveAndCollect(collision.transform));
                
            }
        }
    }
    public IEnumerator MoveAndCollect(Transform target)
    {
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 8 * Time.deltaTime);
            yield return 0;
        }
        Destroy(gameObject);
    }
}
