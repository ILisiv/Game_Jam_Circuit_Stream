using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float _camRotation;
    public bool _invertMouse = false;
    public Transform cam;

    protected PlayerInput _input;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        _input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        //rotate the camera up and down based on the mouse movement
        _camRotation += _input._mouseY * Time.deltaTime * _input._turnSpeed * (_invertMouse ? 1 : -1);
        _camRotation = Mathf.Clamp(_camRotation, -85f, 85f);
        cam.localRotation = Quaternion.Euler(_camRotation, 0, 0); 
    }
}
