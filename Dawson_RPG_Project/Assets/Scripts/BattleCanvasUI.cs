using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BattleCanvasUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;

    public Slider hPSlider;

    public void SetHUD(Unit unit)
    {
        if (unit != null)
        {
            nameText.text = unit.unitName;
            levelText.text = "Level " + unit.unitLevel;
            hPSlider.maxValue = unit.maxHP;
            hPSlider.value = unit.currentHP;
        }
      
    }

    public void SetHP(int hP)
    {
        hPSlider.value = hP;
    }
}
