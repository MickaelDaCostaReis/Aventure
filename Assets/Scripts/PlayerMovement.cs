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
