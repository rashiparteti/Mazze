using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;  // Movement speed
    public float sensitivity = 2f;  // Rotation sensitivity
    public float jumpForce = 5f;  // Jump force
    public Camera cam;  // Reference to the camera
    public AudioClip runningSound;  // Audio clip for running sound

    private Rigidbody rb;  // Reference to the Rigidbody component
    private AudioSource audioSource;  // Reference to the AudioSource component
    private bool isGrounded;  // Is the player grounded?

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Add AudioSource component if not already present
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Initialize audio source settings
        audioSource.loop = true; // Set audio source to loop
        audioSource.clip = runningSound; // Assign running sound clip
    }

    private void FixedUpdate()
    {
        // Handle player movement and rotation
        PlayerMovement();
        PlayerRotation();
    }

    private void Update()
    {
        // Check if the player is grounded
        if (isGrounded)
        {
            // Check for movement input
            float movX = Input.GetAxis("Horizontal");
            float movZ = Input.GetAxis("Vertical");

            // Check if any movement keys (W, A, S, D) are pressed
            bool isMoving = (Mathf.Abs(movX) > 0.1f || Mathf.Abs(movZ) > 0.1f);

            // Toggle audio playback based on movement input
            if (isMoving && !audioSource.isPlaying)
            {
                audioSource.Play(); // Start playing the running sound
            }
            else if (!isMoving && audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop playing the running sound
            }
        }

        // Handle jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void PlayerMovement()
    {
        // Get input for movement
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(movX, 0, movZ).normalized;

        // Check for obstacles in movement direction
        if (!IsPathBlocked(moveDirection))
        {
            Vector3 movePlayer = transform.TransformDirection(moveDirection) * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movePlayer);
        }
    }

    bool IsPathBlocked(Vector3 direction)
    {
        // Cast a small ray in the direction of movement to check for obstacles
        RaycastHit hit;
        float distance = speed * Time.fixedDeltaTime;
        bool isBlocked = Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, distance);

        // Optional: Debug ray to visualize in the scene
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * distance, Color.red);

        // Return true if the path is blocked by any collider
        return isBlocked;
    }

    void PlayerRotation()
    {
        // Get input for rotation
        float rotateY = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, rotateY, 0) * sensitivity;
        transform.Rotate(rotation);

        float rotateX = Input.GetAxis("Mouse Y");
        Vector3 rotation1 = new Vector3(rotateX, 0, 0) * sensitivity;
        transform.Rotate(-rotation1);
    }

    void Jump()
    {
        // Add force for jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
