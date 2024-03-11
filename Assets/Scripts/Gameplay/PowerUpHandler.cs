using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] PowerUpUI powerUpUI;
    PlayerControls playerControls;
    float maxPowerupBuildup = 100;
    float currentPowerupBuildup =0 ;
    [SerializeField] int powerupBuildupRate =10; 
    [SerializeField] int killsNecesaryForIncrease =3; 
    int killCount = 0;
    [SerializeField] float powerupDuration =4;
    float powerupCounter=0;
    [SerializeField] float powerupMaxIncrease = 1.10f; 
    bool isActive = false;

    private void Start() {
        powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
        playerControls = FindObjectOfType<PlayerControls>();
    }
    public void ActivatePowerUp()
    {
        if(currentPowerupBuildup >= maxPowerupBuildup /2 && !isActive)
        {
            //activate powerup
            isActive = true;
            powerUpUI.ActivatePowerUp();
            playerControls.SetTimeBetweenShots(0);
            Time.timeScale = 0;
            
        }
    }
    private void Update() {
        if (isActive)
        {
           powerupCounter += Time.unscaledDeltaTime;
           if(powerupCounter >= powerupDuration)
           {
            Time.timeScale = 1;
            powerupCounter = 0;
            currentPowerupBuildup = 0;
            maxPowerupBuildup *= powerupMaxIncrease;
            powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
            isActive = false;
            playerControls.ResetTimeBetweenShots();
           }
        }
    }
    public void AddPowerupBuildup(int value)
    {
        killCount = value > 4? killCount + value : killCount +1;
            if(killCount % killsNecesaryForIncrease == 0)
            {
                currentPowerupBuildup += powerupBuildupRate;
                powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
            }
        
    }
}
