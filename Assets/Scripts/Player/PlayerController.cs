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

    public float sensitivity = 1.0f;

    [Header("Player Controls")]
    public PlayerControls playerControls;
    private InputAction moveControls;
    public Vector2 viewDirection;
    public Vector2 moveDirection;
    public Vector2 lastMoveDirection = Vector2.zero;

    [Header("Misc")]
    public Camera playerCam;
    public float detectionDistance;
    public List<string> inventory = new List<string>();
    public List<string> stomach = new List<string>();
    public int noDucksEaten;
    public QuestManager QM;
    public float heightOffset = 1.0f;

    //drawing the radius to see where the detection is
    private GameObject radiusVisual; // Declare the GameObject outside of any method


    private void Awake()
    {
        playerControls = new PlayerControls();
        
        // playerControls.Character.Movement.performed += e => moveDirection = e.ReadValue<Vector2>();
        // playerControls.Character.View.performed += e => viewDirection = e.ReadValue<Vector2>();
        
        // playerControls.Enable();

        //Get Body and set important vals
        rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 5;
        //detectionDistance = GameManager.Instance.detectionRadius;
        detectionDistance = 5;
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

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
        // if (rb.velocity.magnitude > maxSpeed)
        // {
        //     // If it does, normalize the velocity vector to maintain direction and multiply by maxSpeed to cap the velocity
        //     rb.velocity = rb.velocity.normalized * maxSpeed;
        // }
        forceDirection = Vector3.zero;

        LookAt();
        // LookAtWithViewControls();
        //may change how looking works


        
    }

    private void LookAtWithViewControls()
    {
        // Read the horizontal value from your view controls (e.g., mouse X axis or joystick horizontal axis)
        float horizontalViewInput = playerControls.Character.View.ReadValue<Vector2>().x;

        // You might want to apply a sensitivity multiplier to control the rotation speed
        // float sensitivity = 1.0f; // Adjust this value as needed

        // Calculate the new rotation around the Y axis based on the input
        Quaternion newRotation = Quaternion.Euler(0f, horizontalViewInput * sensitivity, 0f);

        // Apply the rotation to the player
        rb.MoveRotation(rb.rotation * newRotation);
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0;
        if(moveControls.ReadValue<Vector2>().sqrMagnitude > .1f && direction.sqrMagnitude > .1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
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
        QM.CompletionStatus();
        StartCoroutine(InteractCoroutine());
        Debug.Log("lets eat");
    }


    IEnumerator InteractCoroutine()
    {
        // RaycastHit hit;

        // Vector3 forward = transform.TransformDirection(Vector3.forward) * detectionDistance;
        // Debug.DrawLine(transform.position, transform.position + forward, Color.red, 20.0f);

        // RaycastHit hit;
        // Vector3 startPosition = transform.position + Vector3.up * heightOffset; // Modified start position with height offset
        // Vector3 forward = transform.TransformDirection(Vector3.forward) * detectionDistance;
        // Debug.DrawLine(startPosition, startPosition + forward, Color.red, 20.0f);

        // if(Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        // {
        //     Debug.Log("Hit: " + hit.collider.name);
        //     Interactable interactableComponent = hit.collider.GetComponent<Interactable>();
        //     if (interactableComponent != null)
        //     {
        //         yield return interactableComponent.Interact(); // Assuming this code is inside a Coroutine since 'yield return' is used
        //     }
        // }

        Vector3 centerPosition = transform.position + Vector3.up * heightOffset; // Center position for sphere check
        Collider[] hitColliders = Physics.OverlapSphere(centerPosition, detectionDistance);

        foreach (var hitCollider in hitColliders)
        {
            Interactable interactableComponent = hitCollider.GetComponent<Interactable>();
            if (interactableComponent != null)
            {
                Debug.Log("Interacting with: " + hitCollider.name);
                yield return interactableComponent.Interact();
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 centerPosition = transform.position + Vector3.up * heightOffset;
        Gizmos.color = Color.red; // Set the color of the Gizmos
        Gizmos.DrawWireSphere(centerPosition, detectionDistance); // Draw a wireframe sphere
    }

    public void AddToInventory(string itemID)
    {
        inventory.Add(itemID);
        Debug.Log("Item added to inventory: " + itemID);
    }

    private void Update()
    {
        // Debug.Log(rb.velocity);
        DrawRadius();
    }


    //temporarily here to draw the radius around a player for debuging purposes
    private void DrawRadius()
    {
        ClearRadius();

        // Create a new empty GameObject to hold the line renderer
        radiusVisual = new GameObject("RadiusVisual");
        LineRenderer lineRenderer = radiusVisual.AddComponent<LineRenderer>();

        // Configure the line renderer settings
        lineRenderer.positionCount = 360; // Number of vertices for the circle
        lineRenderer.startWidth = 0.1f; // Thickness of the line
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = false; // Use local space for vertices

        // Calculate points for the circle
        Vector3[] points = new Vector3[360];
        for (int i = 0; i < 360; i++)
        {
            float angle = Mathf.Deg2Rad * i;
            float x = Mathf.Sin(angle) * detectionDistance;
            float z = Mathf.Cos(angle) * detectionDistance;
            points[i] = new Vector3(x, 0f, z);
        }

        // Set the points for the line renderer
        lineRenderer.SetPositions(points);

        // Set the position of the circle around the player
        radiusVisual.transform.position = transform.position;
    }

    private void ClearRadius()
    {
        // If radiusVisual exists, destroy it to clear the visual radius
        if (radiusVisual != null)
        {
            Destroy(radiusVisual);
        }
    }

    public void duckEaten()
    {
        noDucksEaten++; 
    }
}
