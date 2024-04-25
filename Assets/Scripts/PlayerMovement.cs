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
