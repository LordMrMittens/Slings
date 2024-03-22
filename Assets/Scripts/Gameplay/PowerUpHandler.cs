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
    float thisPowerupDuration =0;
    float powerupCounter=0;
    [SerializeField] float powerupMaxIncrease = 1.10f;
    //the below is the number of kills needed to increase the powerup buildup 
    //i.e if set to 3, then if the player kills over 3 bombs with one shot the powerup buildup will increase by the number of bombs killed instead of 1 
    //for each subsequent kill
    [SerializeField] int KillMultiplierBonusLimit =7;
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
            thisPowerupDuration = powerupDuration * (currentPowerupBuildup / maxPowerupBuildup);
            powerUpUI.ActivatePowerUp();
            playerControls.SetTimeBetweenShots(0);
            Time.timeScale = 0;
            
        }
    }
    private void Update()
    {
        PowerUpCountdown();
    }

    private void PowerUpCountdown()
    {
        if (isActive)
        {
            powerupCounter += Time.unscaledDeltaTime;
            if (powerupCounter >= thisPowerupDuration)
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
        killCount = value > KillMultiplierBonusLimit ? killCount + value : killCount +1;
        
            if(killCount >= killsNecesaryForIncrease)
            {
                while(killCount > 0)
                {
                killCount -= killsNecesaryForIncrease;
                currentPowerupBuildup += powerupBuildupRate;
                if(currentPowerupBuildup >= maxPowerupBuildup)
                {
                    currentPowerupBuildup = maxPowerupBuildup;
                }
                powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
                }
                killCount = 0;
            }
        
    }
}
