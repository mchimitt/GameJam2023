using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewPlayerMovement : MonoBehaviour
{

    PlayerInput playerInput;

    InputAction moveAction;

    [SerializeField] public Animator myAnimator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerJump playerJump;
    public float playerDirection = 1;

    [SerializeField] float speed = 10000000;



    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        playerJump = GetComponent<PlayerJump>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * speed *  Time.deltaTime;
        //Debug.Log(direction);


        if ((direction.x != 0 || direction.y != 0)) //if have extra time, add up and down walking anim
        {
            myAnimator.SetBool("isWalking", true);
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
                // right
                playerDirection = 1;
            }
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
                // left
                playerDirection = -1;
            }
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }


    }

}



