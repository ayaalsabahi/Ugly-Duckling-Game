using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayerControls playerControls;
    private InputAction movementControls;
    private InputAction interactControls;
    private Vector3 moveDirection  = Vector3.zero;
    private Vector3 lastMoveDirection  = Vector3.zero;


    private void Awake()
    {
        playerControls = new PlayerControls();
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
        moveDirection = movementControls.ReadValue<Vector3>();
        //update movement base on key inputs
        if(moveDirection != Vector3.zero)
        {
            lastMoveDirection = moveDirection;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("lets eat");
    }

}
