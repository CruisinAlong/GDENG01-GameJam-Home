using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 45f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);

    public float liftSpeed = 1f; // Simple upward speed

    public GameObject mode4Object;
    public static bool isMoving = false;
    public LayerMask layerMask;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        if (mode4Object != null)
            mode4Object.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Cache input for use in FixedUpdate
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Set isMoving to true if any movement input is detected
        isMoving = Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f;
        
        HandleMovementSound();
        
        // Camera follows the player's back at all costs
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + transform.rotation * cameraOffset;
            cameraTransform.LookAt(transform.position);
        }

        // Activate/deactivate the mode 4 object based on PlayerModeManager
        if (mode4Object != null)
        {
            bool shouldBeActive = PlayerModeManager.Instance != null &&
                                  PlayerModeManager.Instance.currentMode == PlayerMode.Mode4;
            if (mode4Object.activeSelf != shouldBeActive)
                mode4Object.SetActive(shouldBeActive);
            if (PlayerModeManager.Instance != null && PlayerModeManager.Instance.currentMode == PlayerMode.Mode4 && rb.velocity.y > 0f && !Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            }


        }
    }

    private void HandleMovementSound()
    {
        if (isMoving)
        { 
            SfxManager.instance.PlayLoopingSFX(EventNames.SFXNames.ROOMBA, 0.2f);
        }
        else
        {
            SfxManager.instance.StopSFX(EventNames.SFXNames.ROOMBA);
        }
    }

    private void FixedUpdate()
    {
        // Handle rotation
        if (Mathf.Abs(horizontalInput) > 0.01f)
        {
            float yRotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, yRotation, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // Handle movement
        if (Mathf.Abs(verticalInput) > 0.01f)
        {
            Vector3 moveDir = transform.forward * verticalInput;
            rb.MovePosition(rb.position + moveDir.normalized * moveSpeed * Time.fixedDeltaTime);
        }

        // Handle vertical lift with physics
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, liftSpeed, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }



        bool touchGround = Physics.Raycast(transform.position, transform.up, 10f, layerMask);
        if (touchGround)
        {
            rb.MoveRotation(Quaternion.Euler(0, rb.rotation.eulerAngles.y, 0));
        }
    }
}
