using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerT;
    public float zoffset = -10f;

    void Start()
    {
        // Automatically find the player if not assigned in the Inspector
        if (playerT == null)
        {
            playerT = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (playerT != null)
        {
            // Log player position (for debugging)
            Debug.Log("Player position: " + playerT.position);

            // Follow the player with adjustable zOffset
            Vector3 newPosition = new Vector3(playerT.position.x, playerT.position.y, zoffset);
            transform.position = newPosition;
        }
    }
}
