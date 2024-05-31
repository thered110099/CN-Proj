using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject targetPrefab; // The prefab of the target to follow (assign your character's prefab here)
    private Transform target; // The actual target transform

    public float distance = 5.0f; // Distance from the target
    public float height = 2.0f; // Height above the target
    public float smoothSpeed = 10.0f; // Smoothness of camera movement

    void Start()
    {
        if (targetPrefab != null)
        {
            target = Instantiate(targetPrefab).transform;
        }
        else
        {
            Debug.LogWarning("No target prefab assigned to the camera.");
        }
    }

    void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + Vector3.up * height - target.forward * distance;

        // Smoothly interpolate between the current and desired positions
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target.position);
    }
}
