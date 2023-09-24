using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;          // Player's movement speed.
    public float jumpForce = 10.0f;         // Force applied when jumping.
    public Transform groundCheck;           // A reference to an empty GameObject placed at the player's feet.
    public LayerMask groundLayer;           // Layer mask to define what is considered ground.

    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        if(isGrounded == true)
        {
            Debug.Log("YAY IM ON THE GROUND");
        }



        // Player movement.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;

        // Apply movement to the Rigidbody.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Player jump.
        if (isGrounded && isJumping == false && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        } else
        {
            isJumping = false;
        }
    }
}
