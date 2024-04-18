using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform pointA, pointB;
    private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 Scale;
    private bool goingLeft;

    [Header("Health")]
    [SerializeField] private GameObject[] items;
    [SerializeField] private float maxhealth;
    private float currenthealth;

    [Header("Drops")]
    [SerializeField] private List<ItemDrops> dropsList = new List<ItemDrops>();


    private void Awake()
    {
        currenthealth = maxhealth;
        enemy = transform;
        Scale = enemy.localScale;
        goingLeft = true;
    }
    private void Update()
    {
        if (goingLeft)
        {
            if(enemy.position.x >= pointA.position.x) 
                moving(-1);
            else
                ChangeDirection();
        }
        else
        {
            if (enemy.position.x <= pointB.position.x)
                moving(1);
            else
                ChangeDirection();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Die();
        }
    }

    private void moving(int direction)
    {
        enemy.localScale = new Vector3(-Mathf.Abs(Scale.x)*direction, Scale.y, Scale.z);  
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *direction * speed, enemy.position.y, enemy.position.z);
    }

    private void ChangeDirection()
    {
        goingLeft = !goingLeft;
    }

    public void takeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, maxhealth);
        if (currenthealth > 0)
        {
            // animation.SetTrigger("Hurt");
        }
        else
        {
            //animation.SetTrigger("Death");
            // use Die() in animator !!!!!!!!!!!!!!!!!!!!!!
            Die();
        }
    }
    public void Die()
    {
        foreach (ItemDrops itemDrop in dropsList)
        {
            if (Random.Range(0f, 100f) <= itemDrop.dropChance)
            {
                InstatiateDrop(itemDrop.item, itemDrop.itemPrefab);
            }
        }
        gameObject.SetActive(false);
        
    }

    void InstatiateDrop(Item item, GameObject drop)
    {
        if (drop)
        {
            GameObject droppedItem = Instantiate(drop, transform.position, Quaternion.identity);
            Collectible collectible = droppedItem.GetComponent<Collectible>();
            collectible.InitialiseItem(item);
        }
    }
}
