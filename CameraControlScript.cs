using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    // Camera sensitivity setting (1 to 100)
    public float sensitivity = 50.0f;

    // Constant of proportionality
    public float constantC = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Get player input
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        // Calculate input intensity (assuming maximum input value is 1 for simplicity)
        float inputIntensity = Mathf.Sqrt(inputX * inputX + inputY * inputY);

        // Clamp input intensity to max value of 1
        inputIntensity = Mathf.Clamp(inputIntensity, 0, 1);

        // Calculate camera movement speed based on sensitivity, player input, and constant C
        float movementSpeedX = constantC * sensitivity * inputX;
        float movementSpeedY = constantC * sensitivity * inputY;

        // Apply movement speed to camera rotation
        transform.Rotate(new Vector3(-movementSpeedY, movementSpeedX, 0) * Time.deltaTime, Space.World);
    }
}
