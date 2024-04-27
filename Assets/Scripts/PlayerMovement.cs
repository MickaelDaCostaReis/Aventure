using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    private Rigidbody2D body;

    private SpriteRenderer spriteRenderer;


    [SerializeField] private float speed;
    [SerializeField] private Sprite sprite_W;
    [SerializeField] private Sprite sprite_S;
    [SerializeField] private Sprite sprite_Q;
    [SerializeField] private Sprite sprite_D;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    //Change la direction du perso :
    private void Flip()
    {
        if (horizontal > 0.01f)
            spriteRenderer.sprite = sprite_D;
        else if (horizontal < -0.01f)
            spriteRenderer.sprite = sprite_Q;
        if (vertical < -0.01f)
            spriteRenderer.sprite = sprite_S;
        else if (vertical > 0.01f)
            spriteRenderer.sprite = sprite_W;
    }
}



/* essai d'intégration de l'input system
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private SpriteRenderer spriteRenderer;


    [SerializeField] private float speed;
    [SerializeField] private Sprite sprite_W;
    [SerializeField] private Sprite sprite_S;
    [SerializeField] private Sprite sprite_Q;
    [SerializeField] private Sprite sprite_D;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

   

    // Movement :
    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        body.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode2D.Force);
    }
}
*/