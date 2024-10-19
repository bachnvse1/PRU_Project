using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End_Game : MonoBehaviour
{
    public GameObject overlay;
    public Button restartButton;

    void Start()
    {
        // Đảm bảo các nút và màn mờ bị ẩn lúc đầu
        overlay.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Gán sự kiện cho nút Restart
        restartButton.onClick.AddListener(RestartGame);
        // Gán sự kiện cho nút Continue
    }

    // Hàm để gọi khi muốn hiện overlay và nút
    public void ShowOverlay()
    {
        overlay.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Hàm xử lý khi nhấn nút Restart
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại scene hiện tại
    }
}
