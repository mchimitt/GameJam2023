using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour
{
    private CharacterController _characterController;

    //Jump Variables
    private Vector3 _playerVelocity;

    private bool _groundedPlayer;

    [SerializeField] private float _jumpHeight = 5.0f;

    private bool _jumpPressed = false;

    private float _gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementJump(); 
    }

    void MovementJump()
    {
        _groundedPlayer = _characterController.isGrounded;

        //If on ground stop vertical movement
        if(_groundedPlayer)
        {
            _playerVelocity.y = 0.0f;
        }

        //if proved and on ground player jump weee
        if(_jumpPressed && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -1.0f* _gravityValue);
            _jumpPressed = false;
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    void OnJump()
    {
        Debug.Log("Jump pressed");

        //Check if no vert movement
        if(_characterController.velocity.y == 0)
        {
            Debug.Log("Real");
            _jumpPressed = true;
        }
        else
        {
            Debug.Log("false");
        }
    }
}
