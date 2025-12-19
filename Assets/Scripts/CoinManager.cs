using UnityEngine;
using TMPro; // Nếu bạn dùng TextMeshPro

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI coinText; // Kéo Text UI vào đây
    private int coinCount = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}