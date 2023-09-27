using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;          // Player's movement speed.
    public float maxSpeed = 6.0f;           // Player's Max speed.
    public float jumpForce = 10.0f;         // Force applied when jumping.
    public Transform groundCheck;           // A reference to an empty GameObject placed at the player's feet.
    public LayerMask groundLayer;           // Layer mask to define what is considered ground.

    [SerializeField] public Animator myAnimator;
    [SerializeField] SpriteRenderer spriteRenderer;


    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputActionReference movement, attack, jump;

    private Rigidbody rb;
    private Vector2 movementInput;
    private float currentSpeed = 0;
    private Vector3 oldMovementInput;
    private bool isGrounded = false;
    private bool isJumping;

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
        jump.action.performed += PerformJump;
    }



    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        jump.action.performed += PerformJump;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void PerformJump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!myAnimator)
            myAnimator = GetComponentInChildren<Animator>();
        if (!spriteRenderer)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {

        // Player movement.
        float moveHorizontal = movement.action.ReadValue<Vector2>().x;
        float moveVertical = movement.action.ReadValue<Vector2>().y;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;


        // Apply movement to the Rigidbody.
        //rb.velocity = new Vector3(movementInput.x, rb.velocity.y, movementInput.z);
        //rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

        rb.velocity = new Vector3(movementInput.x * moveSpeed, rb.velocity.y, movementInput.y * moveSpeed);
        Debug.Log("movement input is" + movementInput);








        //Player walking animation.
        if (isGrounded && (moveHorizontal != 0 || moveVertical != 0)) //if have extra time, add up and down walking anim
        {
            myAnimator.SetBool("isWalking", true);
            if (moveHorizontal > 0)
                spriteRenderer.flipX = false;
            if (moveHorizontal < 0)
                spriteRenderer.flipX = true;
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }


    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        Debug.Log("Trying to move");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }
}
