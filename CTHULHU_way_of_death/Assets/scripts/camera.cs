using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The anchor point (e.g., the player)
    public float mouseSensitivity = 100f;
    public Vector3 initialOffset = new Vector3(4, 2, -3); // Custom initial offset
    public Vector2 pitchMinMax = new Vector2(-40, 85); // Vertical rotation limits
    public float zoomSpeed = 5f; // Speed of zooming in/out
    public float minZoomDistance = 2f; // Minimum zoom distance
    public float maxZoomDistance = 10f; // Maximum zoom distance
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement

    private float yaw; // Horizontal rotation
    private float pitch; // Vertical rotation
    private bool isRightMouseDown = false;
    private float currentDistance; // Current distance from the target

    void Start()
    {
        // Initialize the current distance based on the initial offset
        currentDistance = initialOffset.magnitude;

        // Set the initial camera position and rotation
        UpdateCameraPosition();
    }

    void Update()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
        {
            isRightMouseDown = true;
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false; // Hide the cursor
        }
        if (Input.GetMouseButtonUp(1)) // Right mouse button released
        {
            isRightMouseDown = false;
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Show the cursor
        }

        // Rotate the camera only if the right mouse button is held down
        if (isRightMouseDown)
        {
            // Get mouse input for rotation
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y); // Clamp vertical rotation
        }

        // Zoom in/out with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentDistance -= scroll * zoomSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minZoomDistance, maxZoomDistance); // Clamp zoom distance

        // Update the camera's position and rotation
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Calculate the desired position and rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredOffset = rotation * initialOffset.normalized * currentDistance;
        Vector3 desiredPosition = target.position + desiredOffset;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}