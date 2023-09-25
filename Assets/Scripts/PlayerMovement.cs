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
    private bool isGrounded = false;
    private bool isJumping;


    private float currentHealth;
    private float maxHealth = 100;

    [SerializeField] private Healthbar healthbar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick();
        }

        // Player movement.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;

        // Apply movement to the Rigidbody.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Player jump.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        void OnMouseClick()
        {
            currentHealth -= 5f;

            if (currentHealth <= 0)
            {

                Destroy(gameObject);
            }
            else
            {
                healthbar.UpdateHealthBar(maxHealth, currentHealth);

            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }
}
