using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public CharacterController controller;
    
    public Camera mainCamera; 

    public Ray ray;
    public RaycastHit hit;

    [SerializeField] private LayerMask _interactable;
    [SerializeField] private LayerMask _pick;
    
    
    //public Transform attachTransform;

    private bool isPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame  
}
