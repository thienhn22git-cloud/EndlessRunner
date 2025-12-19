using UnityEngine;

public class LevelGenerator: MonoBehaviour
{
    public static LevelGenerator instance;

    public GameObject platformPrefab;   // Drag your prefab here
    public Transform lastSpawnPoint;    // The SpawnPoint of the first platform in scene

    void Awake()
    {
        instance = this;
    }

    public void SpawnNextPlatform()
    {
        // 1. Instantiate the new platform at the last known spawn point
        GameObject newPlatform = Instantiate(platformPrefab, lastSpawnPoint.position, Quaternion.identity);

        // 2. Update the 'lastSpawnPoint' to the one inside the newly created platform
        // Note: Make sure your child object is named exactly "SpawnPoint"
        lastSpawnPoint = newPlatform.transform.Find("SpawnPoint");
    }
}