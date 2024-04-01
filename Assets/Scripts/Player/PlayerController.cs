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
    private InputAction movementControls;
    private InputAction interactControls;
    private Vector2 moveDirection  = Vector2.zero;
    private Vector2 lastMoveDirection  = Vector2.zero;


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 5;
    }

    void OnEnable()
    {
        movementControls = playerControls.Character.Movement; 
        movementControls.Enable();

        interactControls = playerControls.Character.Interact;
        interactControls.Enable();
        interactControls.performed += Interact;

    }

    void OnDisable()
    {
        movementControls.Disable();
        interactControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementControls.ReadValue<Vector2>();
        //update movement base on key inputs
        if(moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }
        
        Debug.Log("moveDirection =" + moveDirection);
        Debug.Log("lastMoveDirection =" + lastMoveDirection);   
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("lets eat");
    }

}
