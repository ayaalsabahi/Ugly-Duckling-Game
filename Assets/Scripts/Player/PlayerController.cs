using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [Header("Player Movement")]
    private float moveSpeed;
    private Rigidbody rb;

    [Header("Player Controls")]
    public PlayerControls playerControls;
    public Vector2 viewDirection;
    public Vector2 moveDirection;
    public Vector2 lastMoveDirection = Vector2.zero;


    private void Awake()
    {
        playerControls = new PlayerControls();
        
        playerControls.Character.Movement.performed += e => moveDirection = e.ReadValue<Vector2>();
        playerControls.Character.View.performed += e => viewDirection = e.ReadValue<Vector2>();
        
        playerControls.Enable();

        //Get Body and set important vals
        rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 5;
    }

    void Start()
    {
 
    }

    void Update()
    {
        CalculateView();
        CalculateMovement();
    }

     private void CalculateView()
    {
        
    }

    private void CalculateMovement()
    {

    }



    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("lets eat");
    }

}
