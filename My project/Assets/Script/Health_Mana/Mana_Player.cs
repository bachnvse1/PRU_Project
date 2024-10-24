using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour
{
	public float maxMana = 100f; // Max mana
	private float currentMana;   // Current mana
	public Image manaBar;        // Mana bar image
	public bool isPlayer1;       // Flag to distinguish between Player 1 and Player 2

	void Start()
	{
		// Initialize mana to maximum at the start
		currentMana = maxMana;
		UpdateManaBar();
	}

	void Update()
	{
		// Optional: Display current mana, or handle mana regeneration here
	}

	// Function to decrease mana
	public void UseMana(float amount)
	{
		currentMana -= amount;
		if (currentMana < 0)
		{
			currentMana = 0; // Ensure mana doesn't go below 0
		}
		UpdateManaBar();
	}

	// Function to increase mana
	public void GainMana(float amount)
	{
		currentMana += amount;
		if (currentMana > maxMana)
		{
			currentMana = maxMana; // Ensure mana doesn't exceed the maximum
		}
		UpdateManaBar();
	}

	// Update the mana bar display
	private void UpdateManaBar()
	{
		if (manaBar != null)
		{
			manaBar.fillAmount = currentMana / maxMana;
		}
	}
}
