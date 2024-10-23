using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear : MonoBehaviour
{
    public GameObject itemHeart;  // Tham chiếu đến item_heart
    public float spawnTime = 15f;  // Thời gian xuất hiện item_heart (có thể chỉnh từ Inspector)
    private bool isSpawned = false;  // Kiểm tra xem item_heart đã được spawn chưa
    private float timer = 0f;  // Đếm thời gian

    void Start()
    {
        itemHeart.SetActive(false);  // Ẩn item_heart khi game bắt đầu
    }

    void Update()
    {
        timer += Time.deltaTime;  // Cập nhật thời gian

        // Khi thời gian đạt spawnTime và item chưa được spawn
        if (timer >= spawnTime && !isSpawned)
        {
            SpawnItemHeart();
        }
    }

    void SpawnItemHeart()
    {
        itemHeart.SetActive(true);  // Hiển thị item_heart
        isSpawned = true;  // Đánh dấu là đã spawn
    }
}
