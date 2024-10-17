using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Player : MonoBehaviour
{
    public Image Mana_Bar_P1;
    public Image Mana_Bar_P2;

    // Update health bar for player 1
    public void updateHealthBarP1(float manaNow, float manaMax)
    {
        Mana_Bar_P1.fillAmount = manaNow / manaMax;
    }

    // Update health bar for player 2
    public void updateHealthBarP2(float manaNow, float manaMax)
    {
        Mana_Bar_P2.fillAmount = manaNow / manaMax;
    }
}
