using UnityEngine;

public class FOVAdjustmentScript : MonoBehaviour
{
    // Reference to the Camera component
    private Camera gameCamera;

    // Default FOV setting
    public float defaultFOV = 90f;

    // Enhanced FOV for increased spatial awareness and speed perception
    public float enhancedFOV = 110f;

    // Reduced FOV for improved depth perception
    public float reducedFOV = 70f;

    void Start()
    {
        // Initialize the game camera
        gameCamera = GetComponent<Camera>();
        // Set the camera's FOV to the default value
        SetFOV(defaultFOV);
    }

    // Method to adjust the camera's FOV
    public void SetFOV(float fov)
    {
        if (gameCamera != null)
        {
            gameCamera.fieldOfView = fov;
        }
    }

    // Example method to increase spatial awareness and speed perception
    public void EnhanceFOV()
    {
        SetFOV(enhancedFOV);
    }

    // Example method to improve depth perception
    public void ReduceFOV()
    {
        SetFOV(reducedFOV);
    }

    // Reset FOV to default
    public void ResetFOV()
    {
        SetFOV(defaultFOV);
    }

    // Update or other methods could be added here to dynamically adjust FOV based on gameplay events, player input, or other criteria
}
