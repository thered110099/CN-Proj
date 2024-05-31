using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float cameraRotationSpeed = 50f;

    public float cameraDistance = 5.0f;
    public float cameraHeight = 2.0f;
    public float cameraSmoothSpeed = 10.0f;

    private bool isDead = false;
    private bool isMovementEnabled = true;

    private Vector3 networkPosition;
    private Quaternion networkRotation;


    private GameObject playerCamera;
    private Quaternion originalCameraRotation;



    void Start()
    {
        SetupRigidbody(); // Call the method to set up Rigidbody

        if (photonView.IsMine)
        {
            // Create and attach camera to the player
            playerCamera = new GameObject("PlayerCamera");
            Camera cameraComponent = playerCamera.AddComponent<Camera>();
            playerCamera.transform.SetParent(transform);
            cameraComponent.transform.localPosition = new Vector3(0, cameraHeight, -cameraDistance);
            cameraComponent.transform.localRotation = Quaternion.Euler(10, 0, 0);

            // Save the original camera rotation
            originalCameraRotation = playerCamera.transform.localRotation;
        }
        else
        {
            isMovementEnabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // Update remote player's position and rotation
            transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.deltaTime * 10);
            return;
        }


        if (isDead || !isMovementEnabled)
        {
            // Stop updating the movement if the character is dead or movement is disabled
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 movement = (cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void LateUpdate()
    {
        if (!photonView.IsMine || playerCamera == null)
        {
            return;
        }

        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Update camera position to follow the player smoothly
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position + new Vector3(0, cameraHeight, -cameraDistance), Time.deltaTime * cameraSmoothSpeed);
        playerCamera.transform.LookAt(transform);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trap collided");

            // Check if GameOverManager is found
            GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
            if (gameOverManager == null)
            {
                Debug.LogError("GameOverManager not found in the scene.");
            }
            else
            {
                // Notify the GameOverManager that the player collided with a trap
                gameOverManager.ShowGameOverPanel();
            }

            Destroy(gameObject); // Destroy the player object
        }
    }

    void SetupRigidbody()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            // Add Rigidbody if not already present
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.freezeRotation = true; // Prevent physics from affecting the rotation
        rb.useGravity = true; // Ensure that gravity is enabled
        rb.mass = 1f; // Set a reasonable mass
        rb.drag = 0.5f; // Experiment with drag if needed
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send local player's position and rotation to network
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            // Receive remote player's position and rotation from network
            networkPosition = (Vector3)stream.ReceiveNext();
            networkRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
