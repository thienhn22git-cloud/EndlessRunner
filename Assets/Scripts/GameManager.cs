using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;
    public static GameManager instance;

    [Header("UI Đang Chơi (HUD)")]
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI liveDistanceText;

    [Header("UI Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI totalScoreText;

    [Header("Tham Chiếu Đối Tượng")]
    public Transform playerTransform;

    private int coinsCollected = 0;
    private int distanceReached = 0;
    private float startPositionX;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (playerTransform != null)
        {
            startPositionX = playerTransform.position.x;
        }
        UpdateHUD(); // Khởi tạo UI ban đầu
        gameOverPanel.SetActive(false); // Đảm bảo bảng Game Over bị ẩn
    }

    void Update()
    {
        if (playerTransform != null && !isGameOver)
        {
            // Tính toán khoảng cách thời gian thực
            float currentDist = playerTransform.position.x - startPositionX;
            if (currentDist > distanceReached)
            {
                distanceReached = Mathf.FloorToInt(currentDist);
                UpdateHUD();
            }
        }
    }

    // Hàm gọi từ script Coin.cs khi nhặt được xu
    public void AddCoin()
    {
        if (!isGameOver)
        {
            coinsCollected++;
            UpdateHUD();
        }
    }

    void UpdateHUD()
    {
        // Cập nhật các con số đang chạy trên màn hình
        if (coinCountText != null) coinCountText.text = "Coins: " + coinsCollected;
        if (liveDistanceText != null) liveDistanceText.text = distanceReached + "m";
    }

    public void ShowGameOver()
    {
        isGameOver = true;

        // Công thức: Tổng điểm = (Số xu * 10) + Khoảng cách
        int finalScore = (coinsCollected * 10) + distanceReached;
        
        // Lưu và kiểm tra Kỷ lục (High Score)
        int highscore = PlayerPrefs.GetInt("HighScore: ", 0);
        if (finalScore > highscore)
        {
            PlayerPrefs.SetInt("HighScore: ", finalScore);
            highscore = finalScore;
        }

        // Hiện bảng Game Over
        gameOverPanel.SetActive(true);
        totalScoreText.text = "Total Score: " + finalScore + 
                              "\n<size=30>Coins (x10): " + (coinsCollected * 10) + 
                              "\nDistance: " + distanceReached + "m</size>" +
                              "\n\nBEST: " + highscore;
        
        Time.timeScale = 0f; // Dừng mọi hoạt động trong game
    }

    // Các hàm cho Button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}