using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpack : MonoBehaviour
{
    [SerializeField] private float healing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            collision.GetComponent<Health>().takeHealthpack(healing);
            gameObject.SetActive(false);
        }
    }
    


}
