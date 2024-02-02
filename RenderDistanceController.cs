using UnityEngine;

public class RenderDistanceController : MonoBehaviour
{
    // Engine's maximum render distance capability (in units)
    public float engineCapability = 1000f;

    // Display's maximum effective render distance capability (in units)
    // This could be based on technical specifications or performance testing
    public float displayCapability = 1200f;

    // User's preferred render distance setting (in units)
    // This can be adjusted in the game's settings by the player
    public float userPreference = 800f;

    // Reference to the camera component to adjust its far clipping plane
    private Camera gameCamera;

    void Start()
    {
        gameCamera = GetComponent<Camera>();
        AdjustRenderDistance();
    }

    void AdjustRenderDistance()
    {
        // Determine the effective render distance based on the minimum of engine capability, display capability, and user preference
        float effectiveRenderDistance = Mathf.Min(engineCapability, displayCapability, userPreference);

        // Set the camera's far clipping plane to the effective render distance
        if (gameCamera != null)
        {
            gameCamera.farClipPlane = effectiveRenderDistance;
        }
        else
        {
            Debug.LogError("RenderDistanceController: No camera component found!");
        }
    }

    // Optionally, add a method to update the render distance if the user changes preferences at runtime
    public void UpdateUserPreference(float newUserPreference)
    {
        userPreference = newUserPreference;
        AdjustRenderDistance();
    }
}
