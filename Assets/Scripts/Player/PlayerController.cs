using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [Header("Player Movement")]
    private float moveSpeed;
    public float moveForce = 1f;
    public float maxSpeed = 5f;
    public Vector3 forceDirection = Vector3.zero; 
    private Rigidbody rb;

    [Header("Player Controls")]
    public PlayerControls playerControls;
    private InputAction moveControls;
    public Vector2 viewDirection;
    public Vector2 moveDirection;
    public Vector2 lastMoveDirection = Vector2.zero;

    [Header("Misc")]
    public Camera playerCam;


    private void Awake()
    {
        playerControls = new PlayerControls();
        
        // playerControls.Character.Movement.performed += e => moveDirection = e.ReadValue<Vector2>();
        // playerControls.Character.View.performed += e => viewDirection = e.ReadValue<Vector2>();
        
        // playerControls.Enable();

        //Get Body and set important vals
        rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 5;
    }

    private void OnEnable()
    {
        playerControls.Character.Interact.started += InteractEvent;
        moveControls = playerControls.Character.Movement;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Character.Interact.started -= InteractEvent;
        playerControls.Disable();
    }

    void FixedUpdate()
    {
        forceDirection += moveControls.ReadValue<Vector2>().x * GetCameraRight(playerCam) * moveForce;
        forceDirection += moveControls.ReadValue<Vector2>().y * GetCameraForward(playerCam) * moveForce;
        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        return forward.normalized; 
    }

    private Vector3 GetCameraRight(Camera cam)
    {
        Vector3 right = cam.transform.right;
        right.y = 0;
        return right.normalized; 
    }

    private void InteractEvent(InputAction.CallbackContext context)
    {
        Debug.Log("lets eat");
    }

    private void Update()
    {
        Debug.Log(rb.velocity);
    }

}
