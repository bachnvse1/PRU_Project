using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_teleport : MonoBehaviour
{
    // Vị trí xyz mà người chơi sẽ được di chuyển đến khi va chạm với portal_1
    public Vector3 teleportDestination1;

    // Vị trí xyz mà người chơi sẽ được di chuyển đến khi va chạm với portal_2
    public Vector3 teleportDestination2;

    // Phương thức di chuyển người chơi đến vị trí đích
    private void TeleportPlayer(Vector3 destination)
    {
        transform.position = destination;
        Debug.Log("Player has been teleported to: " + destination);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Thêm thông báo kiểm tra va chạm
        Debug.Log("Player has collided with: " + collision.gameObject.name);

        // Kiểm tra xem vật va chạm có tag là "portal_1"
        if (collision.gameObject.CompareTag("portal"))
        {
            Debug.Log("Portal 1 detected, teleporting player...");
            // Di chuyển người chơi đến vị trí đích 1
            TeleportPlayer(teleportDestination1);
        }
        // Kiểm tra xem vật va chạm có tag là "portal_2"
        else if (collision.gameObject.CompareTag("portal_2"))
        {
            Debug.Log("Portal 2 detected, teleporting player...");
            // Di chuyển người chơi đến vị trí đích 2
            TeleportPlayer(teleportDestination2);
        }
    }
}
