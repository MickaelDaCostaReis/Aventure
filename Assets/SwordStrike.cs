using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrike : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")){
            collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(5);
        }
    }
}
