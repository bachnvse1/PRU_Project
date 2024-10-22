using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{
    public float healthMax = 100f;  // Max health
    private float HealthNow;      // Current health
    public Image healthBar;       // Health bar image
    public float healAmount = 20f;  // Amount of health restored on heart collision

    void Start()
    {
        // Initialize player health to maximum at the start
        HealthNow = healthMax;
        updateHealthBar();
    }

    void Update()
    {
        // Optional: Any updates you want to make on every frame
    }

    void OnMouseDown()
    {
        // Reduce health when clicked
        bloodLoss(10f); // For example, lose 10 health per click
    }

    // Function to reduce health
    public void bloodLoss(float healthLost)
    {
        HealthNow -= healthLost;
        if (HealthNow < 0)
        {
            HealthNow = 0; // Ensure health doesn't go below 0
        }

        // Update the health bar
        updateHealthBar();
    }

    // Function to heal health
    public void Heal(float amount)
    {
        HealthNow += amount;
        if (HealthNow > healthMax)
        {
            HealthNow = healthMax; // Ensure health doesn't exceed the maximum
        }

        // Update the health bar
        updateHealthBar();
    }

    // Update the health bar display
    private void updateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = HealthNow / healthMax;
        }
    }

    // Handle collision with heart items
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            Heal(healAmount); // Heal when colliding with a heart

            // Set the heart to inactive instead of destroying it
            collision.gameObject.SetActive(false);
        }
    }

}
