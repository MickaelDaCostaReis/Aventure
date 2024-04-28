using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public enum PlayerState
{
    walking,
    attacking,
    interacting
}

public class PlayerMovement : MonoBehaviour
{
    private Vector3 change;
    private Rigidbody2D body;
    public PlayerState playerState;
    public Item sword;


    [SerializeField] private float speed;
    private Animator animation;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerState!=PlayerState.attacking && InventoryManager.instance.GetSelectedItem(false)==sword)
        {
            StartCoroutine(AttackCD());
        }
    }
    private IEnumerator AttackCD()
    {
        animation.SetBool("isAttacking",true);
        playerState = PlayerState.attacking;
        yield return null;
        animation.SetBool("isAttacking",false);
        yield return new WaitForSeconds(0.3f);
        playerState= PlayerState.walking;
    }
    // Movement :
    private void FixedUpdate()
    {
        // Inputs :
        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");
        if (change != Vector3.zero)
        {
            animation.SetFloat("MoveX", change.x);
            animation.SetFloat("MoveY", change.y);
            animation.SetBool("isMoving", true);
            playerState=PlayerState.walking;
        }
        else
        {
            animation.SetBool("isMoving", false);
        }
        body.velocity = new Vector2(change.y * speed, body.velocity.y);
        body.velocity = new Vector2(change.x * speed, body.velocity.x);
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