using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    // Reference to the object to respawn
    public GameObject objectToRespawn;

    // Respawn position
    public Vector3 respawnPosition;

    // Respawn rotation
    public Quaternion respawnRotation;

    // Update is called once per frame
    void Update()
    {
        // Check if the object's position reaches 0 on the Z-axis
        if (transform.position.z <= 0)
        {
            // Respawn the object
            Respawn();
        }
    }

    // Function to respawn the object
    void Respawn()
    {
        // Instantiate a new object at the respawn position with the specified rotation
        Instantiate(objectToRespawn, respawnPosition, respawnRotation);

        // Destroy the current object
        Destroy(gameObject);
    }
}
