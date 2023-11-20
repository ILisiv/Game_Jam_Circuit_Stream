using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected PlayerInput _input;
    private CharacterController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        _input = PlayerInput.GetInstance();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    void Move()
    {
        controller.Move((transform.forward * _input._vertical + transform.right *  _input._horizontal) * _input.moveSpeed * Time.deltaTime * _input._moveMultiplier);
    
        if (_input._isGrounded && _input._playerVelocity.y < 0)
        {
            _input._playerVelocity.y = -2f;
        }

        //apply gravity
        _input._playerVelocity.y += _input.gravity * Time.deltaTime;
        // v = u + at
        controller.Move(_input._playerVelocity * Time.deltaTime);
    }

    void RotatePlayer()
    {
        //rotate the player based on the mouse movement
        transform.Rotate(Vector3.up * _input._mouseX * Time.deltaTime * _input._turnSpeed);
    }
}
