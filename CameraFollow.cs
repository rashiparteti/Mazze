using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // Offset from the player's position
    public float rotationSpeed = 5f; // Speed of the camera rotation

    void Update()
    {
        if (player != null)
        {
            // Update the camera's position with the offset
            transform.position = player.position + offset;

            // Rotate the camera to match the player's rotation
            Quaternion targetRotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
