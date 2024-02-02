using UnityEngine;

public class CharacterViewControlScript : MonoBehaviour
{
    // Look sensitivity setting
    public float lookSensitivity = 50.0f;

    // Constant of proportionality
    public float constantK = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Get player input for both horizontal (mouse X) and vertical (mouse Y) movements
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        // Calculate input intensity
        float inputIntensity = Mathf.Sqrt(inputX * inputX + inputY * inputY);

        // Clamp the input intensity to ensure it's within the range [0, 1]
        inputIntensity = Mathf.Clamp(inputIntensity, 0, 1);

        // Calculate the view change rate based on look sensitivity, player input, and constant K
        float viewChangeRateX = constantK * lookSensitivity * inputX;
        float viewChangeRateY = constantK * lookSensitivity * inputY;

        // Apply the view change rate to character's viewpoint
        // For simplicity, we'll adjust the camera's rotation around the Y-axis for horizontal movement and around the X-axis for vertical movement
        transform.Rotate(new Vector3(-viewChangeRateY, viewChangeRateX, 0) * Time.deltaTime, Space.World);
    }
}
