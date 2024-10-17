using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Reference for health bars of player 1 and player 2
    public Image Health_Bar_P1;
    public Image Health_Bar_P2;

    // Update health bar for player 1
    public void updateHealthBarP1(float healthNow, float healthMax)
    {
        Health_Bar_P1.fillAmount = healthNow / healthMax;
    }

    // Update health bar for player 2
    public void updateHealthBarP2(float healthNow, float healthMax)
    {
        Health_Bar_P2.fillAmount = healthNow / healthMax;
    }
}
