using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [field : SerializeField] public  Slider powerUpSlider { get; private set;}
    public void UpdatePowerUpUI(float currentValue, float maxValue)
    {
        powerUpSlider.value = currentValue;
        powerUpSlider.maxValue = maxValue;
    }
    public void ActivatePowerUp()
    {
       
    }
}
