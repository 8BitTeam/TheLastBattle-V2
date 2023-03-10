using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SetHeatlh(float health)
    {
        slider.value = health;
        slider.wholeNumbers = true;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        slider.wholeNumbers = true;
    }
}
