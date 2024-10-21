using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_heart : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs; // Các loại enemy
    [SerializeField]
    Vector3 startPosition; // Vị trí xuất hiện của enemy
    [SerializeField]
    int period = 2; // Mỗi 2 giây xuất hiện 1 enemy
    [SerializeField]
    int MaximumCount = 10; // Số lượng tối đa cho mỗi loại enemy
    float time = 0;
    [SerializeField]
    bool EnableExtend;

    // Define ratios for spawning enemies
    [SerializeField]
    float[] spawnRatios; // e.g., {0.8f, 0.2f} for 80% and 20%

    List<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new List<GameObject>();

        // Tạo trước MaximumCount cho mỗi loại enemy
        foreach (var prefab in prefabs)
        {
            for (int i = 0; i < MaximumCount; i++)
            {
                GameObject newEnemy = Instantiate(prefab);
                newEnemy.SetActive(false); // Chưa kích hoạt ngay
                enemyPool.Add(newEnemy); // Thêm vào pool
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > period)
        {
            GameObject newEnemy = GetRandomFreeEnemy(); // Random chọn một enemy chưa active
            if (newEnemy != null)
            {
                newEnemy.SetActive(true);
                newEnemy.transform.position = new Vector3(Random.Range(-7f, 6.4f), Random.Range(0.5f, 3.6f), newEnemy.transform.position.z);
                time = 0;
            }
        }
    }

    private GameObject GetRandomFreeEnemy()
    {
        List<GameObject> availableEnemies = new List<GameObject>();

        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeSelf)
            {
                availableEnemies.Add(enemy);
            }
        }

        if (availableEnemies.Count > 0)
        {
            // Select enemy based on defined spawn ratios
            int enemyIndex = GetEnemyIndexBasedOnRatio();
            GameObject selectedEnemy = availableEnemies[enemyIndex];
            return selectedEnemy;
        }

        if (EnableExtend)
        {
            int randomPrefabIndex = Random.Range(0, prefabs.Length);
            GameObject newEnemy = Instantiate(prefabs[randomPrefabIndex]);
            newEnemy.SetActive(false);
            enemyPool.Add(newEnemy);
            return newEnemy;
        }

        return null;
    }

    private int GetEnemyIndexBasedOnRatio()
    {
        // Calculate total weight
        float totalWeight = 0;
        foreach (var ratio in spawnRatios)
        {
            totalWeight += ratio;
        }

        // Generate a random number between 0 and total weight
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        for (int i = 0; i < spawnRatios.Length; i++)
        {
            cumulativeWeight += spawnRatios[i];
            if (randomValue < cumulativeWeight)
            {
                return i; // Return the index of the selected enemy
            }
        }

        return 0; // Fallback in case something goes wrong
    }
}
