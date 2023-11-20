using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    protected PlayerInput _input;
    public float _jumpVelocity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        JumpUp();
    }

    void JumpUp()
    {
        if(_input._jump && _input._isGrounded)
        {
            _input._playerVelocity.y = _jumpVelocity;
        }
    }
}
