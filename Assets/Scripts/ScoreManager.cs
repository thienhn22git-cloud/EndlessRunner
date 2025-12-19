using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;
    public TextMeshProUGUI distanceText;

    [Header("Settings")]
    public float startPositionX;
    private int maxDistance = 0;

    void Start()
    {
        // Record where the player starts
        if (playerTransform != null)
        {
            startPositionX = playerTransform.position.x;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate distance moved to the right
            float currentDistance = playerTransform.position.x - startPositionX;

            // Only update if the player has moved further than their record
            // This prevents the score from decreasing if they move backward
            if (currentDistance > maxDistance)
            {
                maxDistance = Mathf.FloorToInt(currentDistance);
                UpdateUI();
            }
        }
    }

    void UpdateUI()
    {
        // Display the distance (e.g., "150m")
        distanceText.text = "HighScore: " + maxDistance.ToString() + "m";
    }
}