using UnityEngine;
using UnityEngine.SceneManagement; // Cần thiết để chuyển cảnh

public class MainMenu : MonoBehaviour
{
    // 1. Bắt đầu game chính
    public void StartGame()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian chạy bình thường
        SceneManager.LoadScene("MainGame"); 
    }

    // 2. Vào màn hướng dẫn
    public void StartTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TutorialScene");
    }

    // 3. Xem thông tin tác giả (Credits)
    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    // 4. Thoát Game
    public void QuitGame()
    {
        Debug.Log("Đã thoát game!"); // Chỉ hiện trong cửa sổ Console của Unity
        Application.Quit(); // Lệnh thoát (chỉ có tác dụng khi đã Build game)
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}