using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player movement
    public float moveSpeed = 5f;

    // Limits for player movement
    public float leftLimit = -5f;
    public float rightLimit = 5f;

    void Update()
    {
        // Get the horizontal movement of the phone
        float movement = Input.acceleration.x;

        // Calculate the new position based on the movement
        Vector3 newPosition = transform.position + Vector3.right * movement * moveSpeed * Time.deltaTime;

        // Clamp the new position within the limits
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);

        // Update the player's position
        transform.position = newPosition;
    }
}
