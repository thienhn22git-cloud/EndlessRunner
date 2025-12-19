using UnityEngine;

public class PlatformTriggers : MonoBehaviour
{
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only spawn if the Player hits it and we haven't spawned yet
        if (collision.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true; 
            LevelGenerator.instance.SpawnNextPlatform();
        }
    }
}