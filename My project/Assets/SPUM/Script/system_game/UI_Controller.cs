using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] Button PauseGame;

    // Thêm hai sprite cho Pause và Resume
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite resumeSprite;

    bool isPause = false; // Kiểm tra trạng thái tạm dừng

    void Start()
    {
        PauseGame.image.sprite = pauseSprite; // Khởi tạo nút với ảnh "Pause"
    }

    void Update()
    {
    }

    // Phương thức xử lý khi nhấn nút Pause
    public void btPauseButtonClick()
    {
        if (isPause)
        {
            isPause = false;
            resumeGame();
            PauseGame.image.sprite = pauseSprite; // Đổi lại ảnh "Pause"
        }
        else
        {
            isPause = true;
            pauseGame();
            PauseGame.image.sprite = resumeSprite; // Đổi ảnh thành "Resume"
        }
    }

    // Tạm dừng trò chơi
    void pauseGame()
    {
        Time.timeScale = 0;
    }

    // Tiếp tục trò chơi
    void resumeGame()
    {
        Time.timeScale = 1;
    }
}