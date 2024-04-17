using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 Scale;
    private bool goingLeft;

    private void Awake()
    {
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
}
