using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Variables for movement
    public float _horizontal { get; private set;} 
    public float _vertical { get; private set;}
    public float _mouseX { get; private set;}
    public float _mouseY { get; private set;}
    public float _moveMultiplier { get; private set;}
    public float _sprintMultiplier = 2f;
    public float moveSpeed = 5f;
    public Vector3 _playerVelocity;
    public bool _isGrounded { get; private set;}
    public float gravity = -9.81f;
    public float _turnSpeed = 500;

    //Variables for ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //bools for inputs
    public bool _fire1 { get; private set;}
    public bool _fire2 { get; private set;}
    public bool _jump { get; private set;}
    public bool _interact { get; private set;}

    //bool for command
    public bool _command { get; private set;}
    public bool _build { get; private set;}   

    bool _clear;

    [SerializeField] bool _captureCursor = true;
    
    //Create a singleton
    public static PlayerInput instance;

    private bool _isDead = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerInput found!");
            Destroy(this);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDead) // Check if the player is dead
        {
            ResetInput();
            GetInput();
            CaptureCursor();
            GroundCheck();
        }
    }
    public void FixedUpdate()
    {
        _clear = true;
    }
    void GetInput()
    {
        
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _moveMultiplier = Input.GetButton("Sprint") ? _sprintMultiplier : 1f;

        _jump = _jump || Input.GetButtonDown("Jump");
        _fire1 = _fire1 || Input.GetButtonDown("Fire1");
        _fire2 = _fire2 || Input.GetButtonDown("Fire2");
        _interact =  _interact || Input.GetKeyDown(KeyCode.E);
        _command = _command || Input.GetKeyDown(KeyCode.P);
        _build = _build || Input.GetKeyDown(KeyCode.B);
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _captureCursor = !_captureCursor;
        }
    }
    void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    public void ResetInput()
    {
        if (!_clear)
            return;
        _fire1 = false;
        _fire2 = false;
        _jump = false;
        _interact = false;
        _command = false;
        _build = false;
    } 
    public static PlayerInput GetInstance()
    {
        return instance;
    }   

    void CaptureCursor()
    {
        if(_captureCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }
}
