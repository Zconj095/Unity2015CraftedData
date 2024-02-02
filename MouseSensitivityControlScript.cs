using UnityEngine;

public class MouseSensitivityControlScript : MonoBehaviour
{
    // Mouse sensitivity setting
    public float mouseSensitivity = 50.0f;

    // Constant of proportionality
    public float constantD = 0.1f;

    void Update()
    {
        // Get raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        // Normalize mouse input from -1 to 1 for simplicity
        // In a real scenario, this might involve calculating the actual movement in units or degrees
        // and then normalizing based on maximum expected input values
        float normalizedMouseX = Mathf.Clamp(mouseX, -1, 1);
        float normalizedMouseY = Mathf.Clamp(mouseY, -1, 1);

        // Calculate mouse input magnitude (normalized)
        float mouseInput = Mathf.Sqrt(normalizedMouseX * normalizedMouseX + normalizedMouseY * normalizedMouseY);

        // Calculate view change rate based on mouse sensitivity, mouse input, and constant D
        float viewChangeRateX = constantD * mouseSensitivity * normalizedMouseX;
        float viewChangeRateY = constantD * mouseSensitivity * normalizedMouseY;

        // Apply the view change rate to camera's rotation
        // Assuming Y-axis for horizontal and X-axis for vertical to simulate typical FPS camera control
        transform.Rotate(new Vector3(-viewChangeRateY, viewChangeRateX, 0) * Time.deltaTime, Space.World);
    }
}
