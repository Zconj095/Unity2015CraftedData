using UnityEngine;

// This script should be attached to the GameObject you want to move.
// Make sure the GameObject has a Rigidbody component.

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player movement
    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement vector to the Rigidbody component to move the GameObject
        rb.AddForce(movement * speed);
    }
}
