using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    private BoxCollider2D boxcollider;
    private Rigidbody2D body;

    [SerializeField] private float speed;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Inputs :
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Flip();
    }

    // Movement :
    private void FixedUpdate()
    {
        body.velocity = new Vector2(vertical * speed, body.velocity.y);
        body.velocity = new Vector2(horizontal * speed, body.velocity.x);
    }

    //pas utilisée pour l'instant TTTTTTTTTTTTTTTTTTTTTT
    private void Flip()
    {
        if (horizontal > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
