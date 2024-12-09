using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Reference to the player
    public Vector3 offset;          // Offset from the player

    void Update()
    {
        // Update camera position based on player position and offset
        transform.position = player.position + offset;

        // Optionally, make the camera always look at the player
        transform.LookAt(player);
    }
}


