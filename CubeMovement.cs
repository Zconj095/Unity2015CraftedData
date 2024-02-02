using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the cube movement

    void Update()
    {
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the cube using its transform
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
